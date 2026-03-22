using MediatR;

public record GetProductsQuery() : IRequest<List<Product>>;