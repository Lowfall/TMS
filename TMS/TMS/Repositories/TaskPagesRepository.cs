using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataBase;
using TMS.Model;

namespace TMS.Repositories
{
    public class TaskPagesRepository: IRepository<TaskPage>
    {
        private TMSBaseModel _baseContext;

        public TaskPagesRepository( TMSBaseModel bc)
        {
            _baseContext = bc;
        }

        public IEnumerable<TaskPage> GetAll()
        {
            return _baseContext.Tasks;
        }

        public TaskPage Get(int id)
        {
            return _baseContext.Tasks.Find(id);
        }

        public void Add(TaskPage taskPage)
        {
            _baseContext.Tasks.Add(taskPage);   
        }

        public void Delete(int id)
        {
            var taskPage = _baseContext.Tasks.Find(id);
            if (taskPage != null)
                _baseContext.Tasks.Remove(taskPage);
        }
    }
}
