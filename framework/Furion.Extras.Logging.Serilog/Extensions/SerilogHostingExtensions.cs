// ------------------------------------------------------------------------
// 版权信息
// 版权归百小僧及百签科技（广东）有限公司所有。
// 所有权利保留。
// 官方网站：https://baiqian.com
//
// 许可证信息
// Furion 项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。
// 许可证的完整文本可以在源代码树根目录中的 LICENSE-APACHE 和 LICENSE-MIT 文件中找到。
// 官方网站：https://furion.net
//
// 使用条款
// 使用本代码应遵守相关法律法规和许可证的要求。
//
// 免责声明
// 对于因使用本代码而产生的任何直接、间接、偶然、特殊或后果性损害，我们不承担任何责任。
//
// 其他重要信息
// Furion 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。
// 有关 Furion 项目的其他详细信息，请参阅位于源代码树根目录中的 COPYRIGHT 和 DISCLAIMER 文件。
//
// 更多信息
// 请访问 https://gitee.com/dotnetchina/Furion 获取更多关于 Furion 项目的许可证和版权信息。
// ------------------------------------------------------------------------

#if !NET5_0
using Microsoft.AspNetCore.Builder;
#endif

using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.Hosting;

/// <summary>
/// Serilog 日志拓展
/// </summary>
public static class SerilogHostingExtensions
{
    /// <summary>
    /// 添加默认日志拓展
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <param name="configAction"></param>
    /// <returns>IWebHostBuilder</returns>
#if !NET5_0
    [Obsolete("Prefer UseSerilog() on IHostBuilder")]
#endif

    public static IWebHostBuilder UseSerilogDefault(this IWebHostBuilder hostBuilder, Action<LoggerConfiguration> configAction = default)
    {
        // 判断是否是单文件环境
        var isSingleFileEnvironment = string.IsNullOrWhiteSpace(Assembly.GetEntryAssembly().Location);

#if !NET8_0 && !NET9_0
        hostBuilder.UseSerilog((context, configuration) =>
        {
            // 加载配置文件
            var config = configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext();

            if (configAction != null) configAction.Invoke(config);
            else
            {
                // 判断是否有输出配置
                var hasWriteTo = context.Configuration["Serilog:WriteTo:0:Name"];
                if (hasWriteTo == null)
                {
                    config.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                      .WriteTo.File(Path.Combine(!isSingleFileEnvironment ? AppDomain.CurrentDomain.BaseDirectory : AppContext.BaseDirectory, "logs", "application..log"), LogEventLevel.Information, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null, encoding: Encoding.UTF8);
                }
            }
        });
#endif

        return hostBuilder;
    }

    /// <summary>
    /// 添加默认日志拓展
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configAction"></param>
    /// <returns></returns>
    public static IHostBuilder UseSerilogDefault(this IHostBuilder builder, Action<LoggerConfiguration> configAction = default)
    {
        // 判断是否是单文件环境
        var isSingleFileEnvironment = string.IsNullOrWhiteSpace(Assembly.GetEntryAssembly().Location);

        builder.UseSerilog((context, configuration) =>
        {
            // 加载配置文件
            var config = configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext();

            if (configAction != null) configAction.Invoke(config);
            else
            {
                // 判断是否有输出配置
                var hasWriteTo = context.Configuration["Serilog:WriteTo:0:Name"];
                if (hasWriteTo == null)
                {
                    config.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                      .WriteTo.File(Path.Combine(!isSingleFileEnvironment ? AppDomain.CurrentDomain.BaseDirectory : AppContext.BaseDirectory, "logs", "application..log"), LogEventLevel.Information, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null, encoding: Encoding.UTF8);
                }
            }
        });

        return builder;
    }

#if !NET5_0
    /// <summary>
    /// 添加默认日志拓展
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configAction"></param>
    /// <returns></returns>
    public static WebApplicationBuilder UseSerilogDefault(this WebApplicationBuilder builder, Action<LoggerConfiguration> configAction = default)
    {
        builder.Host.UseSerilogDefault(configAction);

        return builder;
    }
#endif
}