using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models
{
    [Table("Addresses")] // Eğer s koyup çoğaltmazsak veritabanı kendi çoğul yapıp koyuyor.Bu yüzden yazarken kendimiz sürekli çoğul yazmalıyız.Yoksa karışıklık çıkabilir.
    public class Addresses
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [StringLength(50)]
        public string City { get; set; }

        public virtual Persons Persons { get; set; } //virtual:Ezebilidiğim override edebildiğim datalar anlamına geliyor.Burada one to many yapısı olduğu için Addresses clasında bir tablodan bir kayıt alıyoruz.

    }
}