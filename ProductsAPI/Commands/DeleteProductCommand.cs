﻿using MediatR;

namespace ProductsAPI.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}