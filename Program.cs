using System.Reflection;
using EngDataSource;
using EngService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.OpenApi.Models;
using Phone_Data;


var builder = WebApplication.CreateBuilder(args);

// 让PhoneData变成单例
builder.Services.AddSingleton<PhoneData>();

// 注册依赖EnginnerData
builder.Services.AddSingleton<IEngineerService, EngDataSource_Class>();

// 注册自定义路由约束
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("phone", typeof(PhoneNumberRouteConstraint));
});

// Add services to the container.
// 注册服务AddNewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "123",
        Version = "v1",
        Description = "A brief description of the API",
        Contact = new OpenApiContact
        {
            Name = "Jerry",
            Url = new Uri("https://luxoep.github.io/")
        }
    });
    string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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

// 配置静态文件的OPTIONS信息
// app.UseStaticFiles(new StaticFileOptions
// {
//     OnPrepareResponse = ctx =>
//     {
//         ctx.Context.Response.Headers.Append("Access-Control-Allow-Methods", "GET.POST,PUT");
//         ctx.Context.Response.Headers.Append("IsWrite", "True");
//     }
// });

app.UseAuthorization();

// 允许跨域
app.UseCors(policy =>
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

// API指定允许跨域方式
// app.UseCors(policy =>
//     policy.WithOrigins("https://example.com")
//           .WithMethods("POST", "GET")
//           .AllowAnyHeader());

app.MapControllers();

app.Run();
