using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DALEntity.Models
{
    public class Blog
    {
        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [Required]
        [StringLength(200)]
        public string description { get; set; }

        [Required]
        [StringLength(200)]
        public string BlogEntry { get; set; }
        
        [StringLength(200)]
        public string Pseudonym { get; set; }
        

        public DateTime DateInserted { get; set; }
    }
}
