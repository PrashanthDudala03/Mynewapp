using System;
using System.ComponentModel.DataAnnotations;

namespace Mynewapp.Models
{
    public class Item
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        
        public bool IsActive { get; set; }
    }
}
