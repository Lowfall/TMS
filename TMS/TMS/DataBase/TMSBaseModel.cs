using System;
using System.Data.Entity;
using System.Linq;
using TMS.Model;

namespace TMS.DataBase
{
    public class TMSBaseModel : DbContext
    {
        public TMSBaseModel()
            : base("name=TMSBaseModel")
        {
        }

        public DbSet<Client> Clients { get; set; }  
        public DbSet<Admin> Admins { get; set; }
        public DbSet<TaskPage> Tasks { get; set; }
    }
}