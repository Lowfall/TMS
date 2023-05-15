using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
        private DayPlanTaskRepository dayPlanTaskRepository;
        private MeetingRepository meetingRepository;
        private PomodoroRepository pomodoroRepository;
        private AdminRepository adminRepository;

        public AdminRepository Admins
        {
            get
            {
                if(adminRepository == null)
                {
                    adminRepository = new AdminRepository(db);
                }
                return adminRepository;
            }
        }
        public PomodoroRepository Pomodoros {
            get
            {
                if (pomodoroRepository == null)
                {
                    pomodoroRepository = new PomodoroRepository(db);
                }
                return pomodoroRepository;
            }
        }
        public MeetingRepository Meetings
        {
            get
            {
                if (meetingRepository == null)
                {
                    meetingRepository = new MeetingRepository(db);
                }
                return meetingRepository;
            }
        }
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

        public DayPlanTaskRepository DayPlanTasks {
            get
            {
                if(dayPlanTaskRepository == null)
                {
                    dayPlanTaskRepository = new DayPlanTaskRepository(db);
                }
                return dayPlanTaskRepository;
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
