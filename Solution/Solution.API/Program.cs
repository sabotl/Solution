var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appConfig = new Solution.Infrastructure.Configuration.AppConfig(builder.Configuration);

appConfig.ConfigureServices(builder.Services);


builder.Services.AddScoped<Solution.Domain.Service.ITagService, Solution.Application.Services.TagService>();
builder.Services.AddScoped<Solution.Domain.Repository.ITagRepository, Solution.Infrastructure.Repository.TagRepository>();

builder.Services.AddScoped<Solution.Domain.Service.IPlaceService, Solution.Application.Services.PlaceService>();
builder.Services.AddScoped<Solution.Domain.Repository.IPlaceRepository, Solution.Infrastructure.Repository.PlaceRepository>();

builder.Services.AddScoped<Solution.Domain.Service.IPlaceCategoryService, Solution.Application.Services.PlaceCategoryService>();
builder.Services.AddScoped<Solution.Domain.Repository.IPlaceCategoryRepository, Solution.Infrastructure.Repository.PlaceCategoryRepository>();


builder.Services.AddScoped<Solution.Application.UseCase.TagUseCase>();
builder.Services.AddScoped<Solution.Application.UseCase.PlaceUseCase>();
builder.Services.AddScoped<Solution.Application.UseCase.PlaceCategoryUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
