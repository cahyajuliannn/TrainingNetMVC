using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrainingPertemuan1.Models;

namespace TrainingPertemuan1.Context
{
    public class MyContext: DbContext
    {
        public MyContext() : base("MyConnection") {}
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<FormRegist> FormRegists { get; set; }
    }
}