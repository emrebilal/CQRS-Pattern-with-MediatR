using System;

namespace DAL.Commands.Response
{
    public class CreateProductResponse
    {
        public bool IsSuccess { get; set; }
        public Guid ProductId { get; set; }
    }
}
