using GeneralChatApp;
using GeneralChatApp.Data;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ChatContext>(options => options.UseNpgsql("server=127.0.0.1;user=postgres;password=Password12;database=ChatProject"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    
{  
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{user=null}");

app.UseAuthorization();
app.MapHub<ChatHub>("/chat",
    options => {
        options.ApplicationMaxBufferSize = 128;
        options.TransportMaxBufferSize = 128;
        options.LongPolling.PollTimeout = TimeSpan.FromMinutes(1);
        options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
       
    });



app.Run();
