using System.Threading;
using System.Threading.Tasks;
using MediatR;
using pollster.application.Exceptions;
using pollster.domain.Entities;
using pollster.persistence;

namespace pollster.application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQueryHandler : IRequestHandler<GetClientDetailQuery, ClientDetailModel>
    {
        private readonly PoolsterDbContext _context;
        public GetClientDetailQueryHandler(PoolsterDbContext context)
        {
            _context = context;
        }

        public async Task<ClientDetailModel> Handle(GetClientDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Clients
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            return new ClientDetailModel
            {
                Id = entity.ClientId,
                ClientName = entity.ClientName,
                IsActive = entity.IsActive
            };
        }
    }
}