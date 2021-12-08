using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models.Manager
{
    //Database ile model arasındaki yapıyı kuruyor.
    public class DatabaseContext : DbContext // oluşturduğumuz tabloların update,delete,select gibi ifadeleri yakalamamızı sağlayan yapıyı oluşturcak. DbContext sınıfından miras aldık.
    {
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Addresses> Addresses { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new DatabaseCreator());


        }
     

    }

    public class DatabaseCreator : CreateDatabaseIfNotExists<DatabaseContext> // Kayıtlı bir database olmadığı durumda yapıyoruz.Database yoksa oluştur devam et diyoruz.
    {
        //Initialize database ==> Database oluşmadan önce yapılması gereken işlemleri eklemek için kullanılır.
        public override void InitializeDatabase(DatabaseContext context)
        {
            base.InitializeDatabase(context);
        }


        //Seed Database ==> Database oluştuktan sonra eklenmesi gereken işlemler için kullanılır.
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Persons per = new Persons();
                per.Name = FakeData.NameData.GetFirstName();
                per.SurName = FakeData.NameData.GetSurname();
                per.Age = FakeData.NumberData.GetNumber(15, 99);

                context.Persons.Add(per);
            }
            context.SaveChanges(); //Burada kişileri oluşturduk.


            List<Persons> AllPersons = context.Persons.ToList();// Oluşturduğumuz kişileri seçiyoruz.

            foreach (Persons person in AllPersons) // Bir kişi gelcek aşağıda rastgele 1 ile 5 arasında adres yazılacak.
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1, 5); i++) // Fakedatadan 1 ile 5 arasında random adres sayısı belirlicek.
                {
                    Addresses adr = new Addresses();
                    adr.Description = FakeData.PlaceData.GetAddress();
                    adr.City = FakeData.PlaceData.GetCity();
                    adr.Persons = person; // Adresini yazdığımız kişiyi belirtiyoruz.
                    context.Addresses.Add(adr);
                }
            }

            context.SaveChanges();
        }
    }
}