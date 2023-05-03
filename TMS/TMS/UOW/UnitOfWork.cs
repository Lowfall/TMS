using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataBase;
using TMS.Repositories;

namespace TMS.UOW
{
    public class UnitOfWork : IDisposable
    {
        private TMSBaseModel db = new TMSBaseModel();
        private ClientRepository clientRepository;
        private TaskPagesRepository tasksRepository;

        public ClientRepository Clients
        {
            get {
                if (clientRepository == null) {
                    clientRepository = new ClientRepository(db);
                } 
            return clientRepository;
            }
        }
        public TaskPagesRepository Tasks
        {
            get
            {
                if (tasksRepository == null)
                {
                    tasksRepository = new TaskPagesRepository(db);
                }
                return tasksRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
