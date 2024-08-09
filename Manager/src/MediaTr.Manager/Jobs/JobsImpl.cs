using Bogus;
using MediatR;
using MediaTr.Manager.Mock;
using MediaTr.Manager.Model.Agreggates;
using MediaTr.Manager.Requests;
namespace MediaTr.Manager.Jobs;

public class JobsImpl(Faker faker, IMediator mediatr) : IJobs
{
    private readonly Faker _faker = faker;
    private readonly IMediator _mediatr = mediatr;

    public void Execute()
    {
        Order order = new CreateOrder(_faker).Create();
        SendOrder sendOrder = new() { Order = order };
        _ = _mediatr.Send(sendOrder);
    }
}
