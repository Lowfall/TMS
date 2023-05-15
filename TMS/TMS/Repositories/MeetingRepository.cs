using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataBase;
using TMS.Model;

namespace TMS.Repositories
{
    public class MeetingRepository : IRepository<Meeting>
    {
         private TMSBaseModel _baseContext;

         public MeetingRepository(TMSBaseModel bc)
         {
             _baseContext = bc;
         }

         public IEnumerable<Meeting> GetAll()
         {
             return _baseContext.Meetings;
         }

         public Meeting Get(int id)
         {
             return _baseContext.Meetings.Find(id);
         }

         public void Add(Meeting meeting)
         {
             _baseContext.Meetings.Add(meeting);
         }


         public void Delete(int id)
         {
             var meeting = _baseContext.Meetings.Find(id);
             if (meeting != null)
                 _baseContext.Meetings.Remove(meeting);
         }
    }
    
}
