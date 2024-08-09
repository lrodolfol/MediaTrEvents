﻿using MediatR;

namespace MediaTr.Manager.Requests;

public class Handler : IRequestHandler<SendOrder>
{
    public Task Handle(SendOrder request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Executando para {request.Order.User.Name}");

        return Task.CompletedTask;
    }
}
