using Bogus;
using MediatR;
using MediaTr.Manager.Mock;
using MediaTr.Manager.Model.Agreggates;
using MediaTr.Manager.Requests;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddSingleton<Faker>(x =>
{
    return new Faker("pt_BR");
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/senPayment", (IMediator mediatr, Faker faker) =>
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