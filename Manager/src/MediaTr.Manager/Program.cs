using Bogus;
using Hangfire;
using MediatR;
using MediaTr.Manager.Configurations;
using MediaTr.Manager.Mock;
using MediaTr.Manager.Model.Agreggates;
using MediaTr.Manager.Requests;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Hangfire");

builder.Services.AddInjection();
builder.Services.AddHangfire((sp, config) =>
{
    config.UseSqlServerStorage(connectionString);
});
builder.Services.AddHangfireServer();

var app = builder.Build();
app.AddAPIDoc();
app.UseHangfireServer();
app.UseHangfireDashboard();

app.UseHttpsRedirection();


app.MapGet("/sendPayment", (IMediator mediatr, Faker faker) =>
{
    Order order = new CreateOrder(faker).Create();
    SendOrder sendOrder = new() { Order = order };

    var result = mediatr.Send(sendOrder);
    return "Payment";
})
.WithName("SendPayment")
.WithOpenApi();

app.Run();