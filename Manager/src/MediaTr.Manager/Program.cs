using Bogus;
using MediatR;
using MediaTr.Manager.Configurations;
using MediaTr.Manager.Mock;
using MediaTr.Manager.Model.Agreggates;
using MediaTr.Manager.Requests;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInjection();

var app = builder.Build();

app.UseHttpsRedirection();


app.MapGet("/sendPayment", (IMediator mediatr, Faker faker) =>
{
    Order order = new CreateOrder(faker).Create();
    SendOrder sendOrder = new() { Order = order };

    mediatr.Send(sendOrder);

    Console.WriteLine("Payment");
    return "Payment";
})
.WithName("SendPayment")
.WithOpenApi();

app.Run();