using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataBase;
using TMS.Model;
using TMS.ViewModel;

namespace TMS.Repositories
{
    public class PomodoroRepository : IRepository<Pomodoro>
    {
        private TMSBaseModel _baseContext;

        public PomodoroRepository(TMSBaseModel bc)
        {
            _baseContext = bc;
        }

        public IEnumerable<Pomodoro> GetAll()
        {
            return _baseContext.Pomodoros;
        }

        public Pomodoro Get(int id)
        {
            return _baseContext.Pomodoros.Find(id);
        }
        public void Add(Pomodoro client)
        {
            _baseContext.Pomodoros.Add(client);
        }


        public void Delete(int id)
        {
            var  pomodoro = _baseContext.Pomodoros.Find(id);
            if (pomodoro != null)
                _baseContext.Pomodoros.Remove(pomodoro);
        }
    }
}
