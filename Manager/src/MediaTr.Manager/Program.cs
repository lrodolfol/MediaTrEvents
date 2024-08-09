using Bogus;
using Hangfire;
using MediatR;
using MediaTr.Manager.Configurations;
using MediaTr.Manager.Jobs;
using MediaTr.Manager.Mock;
using MediaTr.Manager.Model.Agreggates;
using MediaTr.Manager.Requests;
using Microsoft.AspNetCore.Mvc;

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
    BackgroundJob.Enqueue<JobsImpl>(job => job.Execute());

    return "Payment";
})
.WithName("SendPayment")
.WithOpenApi();

app.MapPost("/schedulePayment", (RecurrentPayload payload) =>
{
    if(payload.TimeToProcess > 59)
        return "Time to process must be less than 60 seconds";

    RecurringJob.AddOrUpdate<JobsImpl>(payload.JobName, job => job.Execute(), $"0/{payload.TimeToProcess} * * * * *");
    
    return $"Job scheduled for each {payload.TimeToProcess} minutes";
})
.WithName("schedulePayment")
.WithOpenApi();

app.Run();