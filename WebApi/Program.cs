
using Infrastructore.Datacontext;
using Infrastructore.Interfaces;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<ILocationService,LocationService>();
builder.Services.AddScoped<ITicketLocationService,TicketLocationService>();
builder.Services.AddScoped<DapperContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebAPI1"));
}


app.UseCors();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
