using DAL.Data;
using DAL.Queries.Response;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.Request
{
    public class GetByIdProductRequest : IRequest<GetByIdProductResponse>
    {
        public Guid Id { get; set; }
    }

    //Handler
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, GetByIdProductResponse>
    {
        public async Task<GetByIdProductResponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var product = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == request.Id);
            if (product == null)
                return null;

            return new GetByIdProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
