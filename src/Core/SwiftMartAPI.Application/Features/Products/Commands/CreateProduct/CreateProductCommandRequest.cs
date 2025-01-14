using MediatR;

namespace SwiftMartAPI.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
{
}

public class CreateProductCommandResponse
{

}

//public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
//{
//    public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
//    {
        
//    }
//}
