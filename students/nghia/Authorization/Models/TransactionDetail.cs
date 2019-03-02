using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Models.Interfaces;

namespace Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
    }

    public class TransactionDetail : IModel, IClient, ICreator
    {
        public Guid id { get; set; }

        [Index("IX_ClientId")]
        public Guid clientId { get; set; }

        [StringLength(20)]
        public string clientCode { get; set; }

        [Index("IX_TransactionIdxPropertyName", IsUnique = true, Order = 0)]
        public Guid transactionId { get; set; }

        [Index("IX_ReferenceId")]
        [Index("IX_ReferenceIdxPropertyName", Order = 0)]
        public Guid referenceId { get; set; }

        [Required]
        [StringLength(50)]
        [Index("IX_PropertyName")]
        [Index("IX_ReferenceIdxPropertyName", Order = 1)]
        [Index("IX_TransactionIdxPropertyName", IsUnique = true, Order = 1)]
        public string propertyName { get; set; }

        public string oldValue { get; set; }

        public string newValue { get; set; }

        [Index("IX_CreatedBy")]
        public Guid? createdBy { get; set; }

        [Index("IX_CreatedDate")]
        public DateTime createdDate { get; set; }

        [StringLength(50)]
        [Index("IX_Creator")]
        public string creator { get; set; }

        [ForeignKey("transactionId")]
        public virtual Transaction transaction { get; set; }
    }
}
