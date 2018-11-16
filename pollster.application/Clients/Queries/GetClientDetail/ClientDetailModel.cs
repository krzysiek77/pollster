using System;
using System.Linq.Expressions;
using pollster.domain.Entities;

namespace pollster.application.Clients.Queries.GetClientDetail
{
    public class ClientDetailModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public bool IsActive { get; set; }

        public static Expression<Func<Client, ClientDetailModel>> Projection
        {
            get
            {
                return client => new ClientDetailModel
                {
                    Id = client.ClientId,
                    ClientName = client.ClientName,
                    IsActive = client.IsActive
                };
            }
        }

        public static ClientDetailModel Create(Client client)
        {
            return Projection.Compile().Invoke(client);
        }
    }
}