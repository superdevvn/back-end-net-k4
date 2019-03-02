using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Models.Commons;
using Models.Interfaces;
using Utilities;

namespace Models
{
    public partial class SuperDevDbContext : DbContext
    {
        public SuperDevDbContext() : base(ConfigurationManager.AppSettings["ConnectionString"])
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<SuperDevDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public override int SaveChanges()
        {
            return SaveChanges(true);
        }

        public int SaveChanges(bool requireAuthorization = true)
        {
            Guid clientId = requireAuthorization ? Utility.ClientId : Guid.Empty;
            string clientCode = requireAuthorization ? Utility.ClientCode : string.Empty;

            Guid userId = requireAuthorization ? Utility.UserId : Guid.Empty;
            string username = requireAuthorization ? Utility.Username : string.Empty;

            bool isMasterClient = requireAuthorization ? Utility.IsMasterClient : true;

            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));
            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    // Cập nhật thông tin Modifier
                    entity.modifiedBy = userId;
                    entity.modifiedDate = DateTime.Now;
                    entity.modifier = username;
                    if (entry.State == EntityState.Added)
                    {
                        // Cập nhật thông tin Creator
                        entity.createdBy = userId;
                        entity.createdDate = DateTime.Now;
                        entity.creator = username;

                        // Nếu không phải là MasterClient, lấy thông tin clientId, clientCode từ Token
                        if (!isMasterClient)
                        {
                            entity.clientId = clientId;
                            entity.clientCode = clientCode;
                        } else
                        {
                            // Cập nhật clientId và clientCode từ Token nếu chưa có
                            if (entity.clientId == Guid.Empty) entity.clientId = clientId;
                            if (string.IsNullOrWhiteSpace(entity.clientCode)) entity.clientCode = clientCode;
                        }
                    }

                    if (entry.Entity is IBeforeSave)
                    {
                        var model = entry.Entity as IBeforeSave;
                        model.BeforeSave(this, entry, requireAuthorization);
                    }
                }
                GenerateTransaction(entry, requireAuthorization);
            }
            return base.SaveChanges();
        }

        private void GenerateTransaction(DbEntityEntry entry, bool requireAuthorization = true)
        {
            var entity = entry.Entity as IModel;
            Guid clientId = requireAuthorization ? Utility.ClientId : Guid.Empty;
            string clientCode = Utility.ClientCode;

            Guid userId = requireAuthorization ? Utility.UserId : Guid.Empty;
            string username = requireAuthorization ? Utility.Username : string.Empty;
            var transaction = new Transaction()
            {
                id = Guid.NewGuid(),
                referenceId = entity.id,
                table = ObjectContext.GetObjectType(entry.Entity.GetType()).Name,

                clientId = clientId,
                clientCode = clientCode,
                createdBy = userId,
                createdDate = DateTime.Now,
                creator = username
            };

            transaction.transactionDetails = new List<TransactionDetail>();

            if (entry.State == EntityState.Added)
            {
                transaction.action = TransactionAction.CREATE.ToString();
                foreach (var propertyName in entry.CurrentValues.PropertyNames)
                {
                    transaction.transactionDetails.Add(new TransactionDetail
                    {
                        id = Guid.NewGuid(),
                        transactionId = transaction.id,
                        referenceId = entity.id,
                        propertyName = propertyName,
                        oldValue = null,
                        newValue = Convert.ToString(entry.CurrentValues[propertyName]),

                        clientId = clientId,
                        clientCode = clientCode,
                        createdBy = userId,
                        createdDate = DateTime.Now,
                        creator = username
                    });
                }
            }
            else if (entry.State == EntityState.Modified)
            {
                transaction.action = TransactionAction.UPDATE.ToString();

                foreach (var prop in entry.OriginalValues.PropertyNames)
                {
                    var oldValue = Convert.ToString(entry.OriginalValues[prop]);
                    var newValue = Convert.ToString(entry.CurrentValues[prop]);

                    if (oldValue != newValue)
                    {
                        transaction.transactionDetails.Add(new TransactionDetail()
                        {
                            id = Guid.NewGuid(),
                            transactionId = transaction.id,
                            referenceId = entity.id,
                            propertyName = prop,
                            oldValue = oldValue,
                            newValue = newValue,

                            clientId = clientId,
                            clientCode = clientCode,
                            createdBy = userId,
                            createdDate = DateTime.Now,
                            creator = username
                        });
                    }
                }
            }
            else if (entry.State == EntityState.Deleted)
            {
                transaction.action = TransactionAction.DELETE.ToString();

                foreach (var prop in entry.OriginalValues.PropertyNames)
                {
                    var transactionDetail = new TransactionDetail()
                    {
                        id = Guid.NewGuid(),
                        transactionId = transaction.id,
                        referenceId = entity.id,
                        propertyName = prop,
                        oldValue = Convert.ToString(entry.OriginalValues[prop]),
                        newValue = null,

                        clientId = clientId,
                        clientCode = clientCode,
                        createdBy = userId,
                        createdDate = DateTime.Now,
                        creator = username
                    };
                    transaction.transactionDetails.Add(transactionDetail);
                }
            }
            Transactions.Add(transaction);
        }
    }
}
