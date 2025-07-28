using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using EFCoreLab.Persistence.Repositories;
using EFCoreLab.WebApi.Infrastructure.CustomJsonConverter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 處理中文轉碼
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin,
                                                 UnicodeRanges.CjkUnifiedIdeographs));

// API Url Path 使用小寫
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers(options =>
{
    // 只輸出 Json, 移除輸出 XML
    options.OutputFormatters.RemoveType<XmlDataContractSerializerOutputFormatter>();
}).AddJsonOptions(options =>
{
    // ViewModel 與 Parameter 顯示為小駝峰命名
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

    // 前後端配合，輸出、入統一使用 UTC 時間
    // 設定參考 https://github.com/dotnet/runtime/issues/1566
    options.JsonSerializerOptions.Converters.Add(new UtcDateTimeConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = $"{AppDomain.CurrentDomain.FriendlyName} V1",
        Version = "v1"
    });

    // Set the comments path for the Swagger JSON and UI.
    var basePath = AppContext.BaseDirectory;
    var xmlFiles = Directory.EnumerateFiles(basePath, "*.xml", SearchOption.TopDirectoryOnly);

    foreach (var xmlFile in xmlFiles) options.IncludeXmlComments(xmlFile);
});

builder.Services.AddDataSource(builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

// 純 Web Api 專案不建議使用此設定
// via https://docs.microsoft.com/zh-tw/aspnet/core/security/enforcing-ssl?view=aspnetcore-6.0&tabs=visual-studio
// app.UseHttpsRedirection();

app.UseHealthChecks("/health");

app.UseSwagger()
   .UseSwaggerUI(options =>
   {
       options.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab Web Api v1");
   });

app.UseRouting();

app.MapDefaultControllerRoute();

app.MapControllers();

app.Run();