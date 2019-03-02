using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Models.Attributes;
using Models.Interfaces;

namespace Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
    }
    public class Transaction: IModel, IClient, ICreator
    {
        public Guid id { get; set; }

        [Index("IX_ClientId")]
        public Guid clientId { get; set; }

        [StringLength(20)]
        public string clientCode { get; set; }

        [Required]
        [StringLength(10)]
        public string action { get; set; }

        [StringLength(50)]
        [Index("IX_Table")]
        public string table { get; set; }

        [Index("IX_ReferenceId")]
        public Guid referenceId { get; set; }
        
        [Index("IX_CreatedBy")]
        public Guid? createdBy { get; set; }

        [Index("IX_CreatedDate")]
        public DateTime createdDate { get; set; }

        [StringLength(50)]
        [Index("IX_Creator")]
        public string creator { get; set; }

        public virtual List<TransactionDetail> transactionDetails { get; set; }
    }

    public enum TransactionAction
    {
        CREATE,
        UPDATE,
        DELETE
    }
}
