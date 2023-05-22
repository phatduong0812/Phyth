﻿using Contracts.Domains;
using Contracts.Domains.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Entities
{
    public class CatalogProduct : EntityAudiBase<long>
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string No { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Summary { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
    }
}
