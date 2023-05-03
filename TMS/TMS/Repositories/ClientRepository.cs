using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataBase;
using TMS.Model;

namespace TMS.Repositories
{
    public class ClientRepository: IRepository<Client>
    {
        private TMSBaseModel _baseContext;

        public ClientRepository( TMSBaseModel bc)
        {
            _baseContext = bc;
        }

        public IEnumerable<Client> GetAll()
        {
            return _baseContext.Clients;
        }

        public Client Get(int id)
        {
            return _baseContext.Clients.Find(id);
        }

        public void Add(Client client)
        {
            _baseContext.Clients.Add(client);   
        }


        public void Delete(int id)
        {
            var client = _baseContext.Clients.Find(id);
            if (client != null)
                _baseContext.Clients.Remove(client);
        }
    }
}
