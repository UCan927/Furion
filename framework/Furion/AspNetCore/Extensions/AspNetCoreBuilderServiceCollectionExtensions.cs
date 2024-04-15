﻿// ------------------------------------------------------------------------
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

using Furion;
using Furion.AspNetCore;
using Furion.SensitiveDetection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Concurrent;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// ASP.NET Core 服务拓展类
/// </summary>
[SuppressSniffer]
public static class AspNetCoreBuilderServiceCollectionExtensions
{
    /// <summary>
    /// 注册 Mvc 过滤器
    /// </summary>
    /// <typeparam name="TFilter"></typeparam>
    /// <param name="mvcBuilder"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IMvcBuilder AddMvcFilter<TFilter>(this IMvcBuilder mvcBuilder, Action<MvcOptions> configure = default)
        where TFilter : IFilterMetadata
    {
        mvcBuilder.Services.AddMvcFilter<TFilter>(configure);

        return mvcBuilder;
    }

    /// <summary>
    /// 注册 Mvc 过滤器
    /// </summary>
    /// <typeparam name="TFilter"></typeparam>
    /// <param name="services"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IServiceCollection AddMvcFilter<TFilter>(this IServiceCollection services, Action<MvcOptions> configure = default)
        where TFilter : IFilterMetadata
    {
        // 非 Web 环境跳过注册
        if (App.WebHostEnvironment == default) return services;

        services.Configure<MvcOptions>(options =>
        {
            options.Filters.Add<TFilter>();

            // 其他额外配置
            configure?.Invoke(options);
        });

        return services;
    }

    /// <summary>
    /// 注册 Mvc 过滤器
    /// </summary>
    /// <param name="services"></param>
    /// <param name="filter"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IServiceCollection AddMvcFilter(this IServiceCollection services, IFilterMetadata filter, Action<MvcOptions> configure = default)
    {
        // 非 Web 环境跳过注册
        if (App.WebHostEnvironment == default) return services;

        services.Configure<MvcOptions>(options =>
        {
            options.Filters.Add(filter);

            // 其他额外配置
            configure?.Invoke(options);
        });

        return services;
    }

    /// <summary>
    /// 添加 [FromConvert] 模型绑定
    /// </summary>
    /// <param name="mvcBuilder"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IMvcBuilder AddFromConvertBinding(this IMvcBuilder mvcBuilder, Action<ConcurrentDictionary<Type, Type>> configure = default)
    {
        mvcBuilder.Services.AddFromConvertBinding(configure);

        return mvcBuilder;
    }

    /// <summary>
    /// 添加 [FromConvert] 模型绑定
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IServiceCollection AddFromConvertBinding(this IServiceCollection services, Action<ConcurrentDictionary<Type, Type>> configure = default)
    {
        // 非 Web 环境跳过注册
        if (App.WebHostEnvironment == default) return services;

        // 定义模型绑定转换器集合
        var modelBinderConverts = new ConcurrentDictionary<Type, Type>();
        modelBinderConverts.TryAdd(typeof(DateTime), typeof(DateTimeModelConvertBinder));
        modelBinderConverts.TryAdd(typeof(DateTimeOffset), typeof(DateTimeOffsetModelConvertBinder));

        // 配置 Mvc 选项
        services.Configure<MvcOptions>(options =>
        {
            // 添加模型绑定器
            options.ModelBinderProviders.Insert(0, new FromConvertBinderProvider(modelBinderConverts));
        });

        // 调用外部方法
        configure?.Invoke(modelBinderConverts);

        return services;
    }
}