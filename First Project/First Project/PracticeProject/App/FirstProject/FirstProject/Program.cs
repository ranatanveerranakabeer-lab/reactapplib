using FirstProject.Application.cs.Interface;
using FirstProject.Application.cs.Services;
using FirstProject.domain.cs.Interface;
using FirstProject.Infrastructure.cs;
using FirstProject.Infrastructure.cs.Repository;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped<IProductInterface,ProductRepository>();  
builder.Services.AddScoped<IUserInterface,UserRepository>();  
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IOrderInterface, OrderRepository>();
builder.Services.AddScoped<ICustomerInterface, CustomerRepository>();//control d kro
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ITransactionInterface, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // React dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

//thk y hmm thk okey
//ya jo hm ny services or interface bnay thy inko inject krdia hy  iska bina  api load nhi hogi ab project run kro
var app = builder.Build();
app.UseCors("AllowReactApp");
//build na krn
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
