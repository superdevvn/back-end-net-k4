using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Attributes;
using Models.Interfaces;

namespace Models.Commons
{
    public class BaseEntity : IModel, IClient, ICreator, IModifier
    {
        public Guid id { get; set; }

        [PreventModify]
        public Guid clientId { get; set; }

        [Required]
        [PreventModify]
        [StringLength(20)]
        public string clientCode { get; set; }

        [PreventModify]
        [Index("IX_CreatedBy")]
        public Guid? createdBy { get; set; }

        [PreventModify]
        [Index("IX_CreatedDate")]
        public DateTime createdDate { get; set; }

        [PreventModify]
        [StringLength(50)]
        [Index("IX_Creator")]
        public string creator { get; set; }

        [Index("IX_ModifiedBy")]
        public Guid? modifiedBy { get; set; }

        [Index("IX_ModifiedDate")]
        public DateTime modifiedDate { get; set; }

        [Index("IX_Modifier")]
        [StringLength(50)]
        public string modifier { get; set; }
    }
}
