using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models.Manager
{
    public class StudentsDatabaseContext:DbContext
    {
        public DbSet <Students> Students { get; set; }
        public DbSet <Classes> Classes { get; set; }

        public StudentsDatabaseContext()
        {
            Database.SetInitializer(new studentDatabaseCreator());
        }
    }

    public class studentDatabaseCreator : CreateDatabaseIfNotExists<StudentsDatabaseContext>
    {
        public override void InitializeDatabase(StudentsDatabaseContext context)
        {
            base.InitializeDatabase(context);
        }
        protected override void Seed(StudentsDatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Classes classes = new Classes();
                classes.Name = FakeData.NameData.GetCompanyName();
                context.Classes.Add(classes);
            }
            context.SaveChanges();

            List<Classes> AllClasses = context.Classes.ToList();

            foreach (Classes classes in AllClasses)
            {
                for (int i = 0; i < 10; i++)
                {
                    Students student = new Students();
                    student.Name = FakeData.NameData.GetFirstName();
                    student.SurName = FakeData.NameData.GetSurname();
                    student.StudentNumber = FakeData.NumberData.GetNumber(1907,9999);
                    student.Classes = classes;
                    context.Students.Add(student);
                }

            }
            context.SaveChanges();
        }
    }
}