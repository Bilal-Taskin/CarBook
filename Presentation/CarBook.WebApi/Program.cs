using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Persistance.Context;
using CarBook.Persistance.Repositories;
using CarBook.Persistance.Repositories.CarRepositories;
using CarBook.Application.Services;
using CarBook.Application.Authors.Mediator.Handlers.AuthorHandler;
using CarBook.Application.Blocks.Mediator.Handlers.BlockHandler;
using CarBook.Application.Features.Mediator.Handlers.BlockHandler;
using CarBook.Application.Interfaces.BlockInterface;
using CarBook.Persistance.Repositories.BlockRepositories;
using CarBook.Application.Interfaces.CarPricingInterface;
using CarBook.Persistance.Repositories.CarPricingRepositories;
using CarBook.Application.Interfaces.TagCloudInterface;
using CarBook.Persistance.Repositories.TagCloudRepositories;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistance.Repositories.CommentRepositories;
using CarBook.Persistance.Repositories.StatisticsRepositories;
using CarBook.Application.Interfaces.StatistcisInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));//type of kullanýmýný araþtýr
builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlockRepository),typeof(BlockRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository),typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository),typeof(StatisticRepository));

builder.Services.AddScoped<GetAboutQueryHanlder>();
builder.Services.AddScoped<GetAboutByIdQueryHanlder>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();


builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHanlder>();
builder.Services.AddScoped<GetBrandQueryHanlder>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();

builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<GetCarByIdQueryHanlder>();
builder.Services.AddScoped<GetCarQueryHanlder>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();


builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHanlder>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHanlder>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();



//mediator sayesinde yukardýaki karmaþýklýktan kurtulup aþaðýdaki kullanýma kavuþuyoruz. CarBook.Application kýsmýna eklediðimiz Services sayesinde bu kullanýmý oluþturduk.
builder.Services.AddApplicationService(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
