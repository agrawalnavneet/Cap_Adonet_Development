using MediatR;

public record AddProductCommand(string Name, int Stock) : IRequest<string>;