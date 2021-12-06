using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models
{
    [Table("Persons")]
    public class Persons
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [StringLength(30), Required]
        //[Required] // Bu alanın zorunlu olduğunu boş geçilemez olduğunu belirtir.
        public string Name { get; set; }
        [StringLength(30), Required]
        public string SurName { get; set; }
        [Required]
        public int Age { get; set; }

        public virtual List<Addresses> Addresses { get; set; } // One to many yapısı birden fazla adresi olabilir bir kişinin. Burada diğer tablodan bir liste alıyoruz.

    }
}