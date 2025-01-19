using MediatR;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;

namespace SwiftMartAPI.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandRequest : IRequest
{
    public int Id { get; set; }
}


public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
{
    public IUnitOfWork _uow { get; set; }

    public DeleteProductCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var productToRemove = await _uow.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

        if (productToRemove is null)
            throw new Exception("Product not found.");

        _uow.GetWriteRepository<Product>().HardDelete(productToRemove);
        await _uow.SaveAsync();

    }
}
