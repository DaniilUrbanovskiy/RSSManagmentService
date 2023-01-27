using Microsoft.EntityFrameworkCore;
using RSSManagmentService.Api.Configurations;
using RSSManagmentService.Api.Infrastructure;
using RSSManagmentService.BLL;
using RSSManagmentService.DataAccess;
using RSSManagmentService.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddTransient<FeedUrlService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<FeedUrlRepository>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddDbContext<SqlContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlContext")));
builder.Services.AddJWTAuthorization(builder.Configuration);
builder.Services.AddAutoMapper(typeof(ApiMappingProfile));
builder.Services.AddCors(o =>
   o.AddDefaultPolicy(b =>
     b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<SqlContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
