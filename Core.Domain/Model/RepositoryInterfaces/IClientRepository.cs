using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.Domain.Model.RepositoryInterfaces
{
    public interface IClientRepository
    {
        void InsertClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        Client RetrieveClient(int id);
        ICollection<Client> RetrieveAllClients();
        void AddOrder(int ClientId, DeliveryOrder order);
    }
}
