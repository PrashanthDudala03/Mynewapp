using System;
using System.ComponentModel.DataAnnotations;

namespace Mynewapp.Models
{
    public class Item
    {
        // Changed from Id to ID to match references in code
        public int ID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastModified { get; set; }
        
        public bool IsActive { get; set; }
        
        // Added CreatedBy property that was referenced in code
        public string CreatedBy { get; set; } = string.Empty;
        
        public string CreatedById { get; set; } = string.Empty;
        
        public string LastModifiedById { get; set; } = string.Empty;
    }
}
