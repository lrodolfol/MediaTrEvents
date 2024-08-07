using MediatR.Pipeline;

namespace MediaTr.Manager.Requests;

public class PreHandler : IRequestPreProcessor<SendOrder>
{
    public Task Process(SendOrder request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Pre processamento handler");
        request.Order.Validate();
        return Task.CompletedTask;
    }
}
