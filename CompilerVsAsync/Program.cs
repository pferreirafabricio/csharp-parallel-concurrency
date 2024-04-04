// Reference: https://dev.to/angelobelchior/por-debaixo-do-capo-asyncawait-e-as-magicas-do-compilador-csharp-28ol

using BlogService = CompilerVsAsync.Services.BlogService;
using BlogServiceByCompiler = CompilerVsAsync.Compiler.BlogService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapGet("/post/{id}", async (int id) =>
{
    BlogService blogService = new();
    var post = await blogService.ObterPostPorIdAsync(id);
    return post;
});
app.MapGet("/post-by-compiler/{id}", async (int id) =>
{
    BlogServiceByCompiler blogService = new();
    var post = await blogService.ObterPostPorIdAsync(id);
    return post;
});

app.Run();
