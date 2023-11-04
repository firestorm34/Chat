global using GeneralChat.Server.Models;
using GeneralChat.Server.DataAccess;
using GeneralChat.Server;
using Microsoft.AspNetCore.Http.Connections;
using GeneralChat.Server.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSignalR();
builder.Services.AddDbContext<ChatContext>(options=>options.UseNpgsql("Host=localhost;Port=5432;Database=ChatProject;" +
    "Username=postgres;Password=Password12"));
builder.Services.AddSingleton<UserServices>();
builder.Services.AddIdentity<User, Role>( options => {
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<ChatContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) 
        .AllowCredentials()); 
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

//app.UseEndpoints( 
//    endpoints => {
//        endpoints.MapControllerRoute(
//            name: "Default",
//            pattern: "/{controller=Home}/"
//        );
//    }
//);

app.MapHub<ChatHub>("/chat",
    options => {
        options.ApplicationMaxBufferSize = 128;
        options.TransportMaxBufferSize = 128;
        options.LongPolling.PollTimeout = TimeSpan.FromMinutes(1);
        options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;

    });
app.MapHub<UserHub>("/UserHub");


app.Run();
