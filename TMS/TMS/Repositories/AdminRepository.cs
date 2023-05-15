using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataBase;
using TMS.Model;

namespace TMS.Repositories
{
    public class AdminRepository
    {
        private TMSBaseModel _baseContext;

        public AdminRepository(TMSBaseModel bc)
        {
            _baseContext = bc;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _baseContext.Admins;
        }

        public Admin Get(int id)
        {
            return _baseContext.Admins.Find(id);
        }

        public void Add(Admin admin)
        {
            _baseContext.Admins.Add(admin);
        }


        public void Delete(int id)
        {
            var admin = _baseContext.Admins.Find(id);
            if (admin != null)
                _baseContext.Admins.Remove(admin);
        }
    }
}

