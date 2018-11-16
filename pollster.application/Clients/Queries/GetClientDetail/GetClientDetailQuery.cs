using MediatR;

namespace pollster.application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQuery : IRequest<ClientDetailModel>
    {
        public int Id { get; set; }
    }
}