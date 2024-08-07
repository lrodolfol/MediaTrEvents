using MediatR;
using MediaTr.Manager.Model.Agreggates;

namespace MediaTr.Manager.Requests;

public class SendOrder : IRequest
{
    public Order Order { get; set; }
}
