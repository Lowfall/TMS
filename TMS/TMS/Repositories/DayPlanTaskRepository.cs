using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataBase;
using TMS.Model;

namespace TMS.Repositories
{
    public class DayPlanTaskRepository:IRepository<DayPlanTask>
    {
        private TMSBaseModel _baseContext;

        public DayPlanTaskRepository(TMSBaseModel bc)
        {
            _baseContext = bc;
        }

        public IEnumerable<DayPlanTask> GetAll()
        {
            return _baseContext.DayPlanTasks;
        }

        public DayPlanTask Get(int id)
        {
            return _baseContext.DayPlanTasks.Find(id);
        }

        public void Add(DayPlanTask dayPlanTask)
        {
            _baseContext.DayPlanTasks.Add(dayPlanTask);
        }


        public void Delete(int id)
        {
            var dayPlanTask = _baseContext.DayPlanTasks.Find(id);
            if (dayPlanTask != null)
                _baseContext.DayPlanTasks.Remove(dayPlanTask);
        }
    }
}
