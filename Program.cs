using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddControllersWithViews(options =>
// {
//     options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
// });

#region 用于windows验证登录
// builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//    .AddNegotiate();

// builder.Services.AddAuthorization(options =>
// {
//     // By default, all incoming requests will be authorized according to the default policy.
//     options.FallbackPolicy = options.DefaultPolicy;
//     // options.FallbackPolicy=new AuthorizationPolicyBuilder()
//     //     .RequireAuthenticatedUser()  // 要求用户身份验证
//     //     .Build();  // 构建授权策略
// });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 启用静态文件
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
