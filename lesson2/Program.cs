using lesson2;
using lesson2.Models;
using Microsoft.AspNetCore.Http.HttpResults;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Catalog catalog = new Catalog();
catalog.Initilize();
catalog.justCrated += Subscriber.CatalogUpdatesCheck;

app.MapGet("/products", GetProducts);
app.MapGet("/products/{id}", (int id)=>GetProductById(id));
app.MapPost("/products", CreateProduct);
app.MapPut("/products", UpdateProduct);
app.MapDelete("/products/{id}", DeleteProduct);


app.Run();

IResult GetProducts()
{
    return Results.Ok(catalog.GetProducts());
}
IResult GetProductById(int id)
{
    return Results.Ok(catalog.GetProductById(id));
}

IResult CreateProduct(Product product)
{
    catalog.AddProduct(product);
    return Results.Created($"/products/{product.Id}",product);
}
IResult DeleteProduct(int id)
{
    return catalog.DeleteProduct(id)? Results.Ok($"Product with id: {id} has been deleted"): Results.NotFound($"Product with id: {id} not found");
}
IResult UpdateProduct(int id, Product product)
{
    
    return catalog.UpdateProduct(id, product)? Results.Ok($"Product with id: {id} has been changed"): Results.NotFound($"Product with id: {id} not found");
}
