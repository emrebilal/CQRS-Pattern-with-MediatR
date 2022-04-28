using DAL.Data;
using DAL.Queries.Response;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.Request
{
    public class GetAllProductRequest : IRequest<List<GetAllProductResponse>>
    {

    }

    //Handler
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductResponse>>
    {
        public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            return ApplicationDbContext.ProductList.Select(product => new GetAllProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            }).ToList();
        }
    }
}
