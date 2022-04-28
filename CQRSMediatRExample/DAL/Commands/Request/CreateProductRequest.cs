using DAL.Commands.Response;
using DAL.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Commands.Request
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    //Handler
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.ProductList.Add(new()
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.Now
            });

            return new CreateProductResponse
            {
                IsSuccess = true,
                ProductId = id
            };
        }
    }
}
