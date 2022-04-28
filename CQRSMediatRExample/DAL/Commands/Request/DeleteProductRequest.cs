using DAL.Commands.Response;
using DAL.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Commands.Request
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public Guid Id { get; set; }
    }

    //Handler
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == request.Id);
            if (deleteProduct == null)
                return null;

            ApplicationDbContext.ProductList.Remove(deleteProduct);

            return new DeleteProductResponse
            {
                IsSuccess = true
            };
        }
    }
}
