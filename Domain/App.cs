using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Appstore.Models
{
    public class App
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(21)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Downloads { get; set; }

        public string ImagePath { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [Required] public Dev Dev { get; set; }
        public int DevId { get; set; }
        public HashSet<Review> Reviews { get; set; } = new HashSet<Review>();

        
    }
}