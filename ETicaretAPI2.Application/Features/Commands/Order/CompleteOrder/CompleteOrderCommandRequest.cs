using MediatR;

namespace ETicaretAPI2.Application.Features.Commands.Order.CompleteOrder
{
    public class CompleteOrderCommandRequest:IRequest<CompleteOrderCommandResponse>
    {
        public string Id { get; set; }
    }
}
