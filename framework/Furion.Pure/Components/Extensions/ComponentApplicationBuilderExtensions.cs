﻿// MIT 许可证
//
// 版权 © 2020-present 百小僧, 百签科技（广东）有限公司 和所有贡献者
//
// 特此免费授予任何获得本软件副本和相关文档文件（下称“软件”）的人不受限制地处置该软件的权利，
// 包括不受限制地使用、复制、修改、合并、发布、分发、转授许可和/或出售该软件副本，
// 以及再授权被配发了本软件的人如上的权利，须在下列条件下：
//
// 上述版权声明和本许可声明应包含在该软件的所有副本或实质成分中。
//
// 本软件是“如此”提供的，没有任何形式的明示或暗示的保证，包括但不限于对适销性、特定用途的适用性和不侵权的保证。
// 在任何情况下，作者或版权持有人都不对任何索赔、损害或其他责任负责，无论这些追责来自合同、侵权或其它行为中，
// 还是产生于、源于或有关于本软件以及本软件的使用或其它处置。

using Furion.Components;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// 组件应用中间件拓展类
/// </summary>
[SuppressSniffer]
public static class ComponentApplicationBuilderExtensions
{
    /// <summary>
    /// 注册依赖组件
    /// </summary>
    /// <typeparam name="TComponent">派生自 <see cref="IApplicationComponent"/></typeparam>
    /// <param name="app"><see cref="IApplicationBuilder"/></param>
    /// <param name="env"><see cref="IWebHostEnvironment"/></param>
    /// <param name="options">组件参数</param>
    /// <returns><see cref="IApplicationBuilder"/></returns>
    public static IApplicationBuilder UseComponent<TComponent>(this IApplicationBuilder app, IWebHostEnvironment env, object options = default)
        where TComponent : class, IApplicationComponent, new()
    {
        return app.UseComponent<TComponent, object>(env, options);
    }

    /// <summary>
    /// 注册依赖组件
    /// </summary>
    /// <typeparam name="TComponent">派生自 <see cref="IApplicationComponent"/></typeparam>
    /// <typeparam name="TComponentOptions">组件参数</typeparam>
    /// <param name="app"><see cref="IApplicationBuilder"/></param>
    /// <param name="env"><see cref="IWebHostEnvironment"/></param>
    /// <param name="options">组件参数</param>
    /// <returns><see cref="IApplicationBuilder"/></returns>
    public static IApplicationBuilder UseComponent<TComponent, TComponentOptions>(this IApplicationBuilder app, IWebHostEnvironment env, TComponentOptions options = default)
        where TComponent : class, IApplicationComponent, new()
    {
        return app.UseComponent(env, typeof(TComponent), options);
    }

    /// <summary>
    /// 注册依赖组件
    /// </summary>
    /// <param name="app"><see cref="IApplicationBuilder"/></param>
    /// <param name="env"><see cref="IWebHostEnvironment"/></param>
    /// <param name="componentType">组件类型</param>
    /// <param name="options">组件参数</param>
    /// <returns><see cref="IApplicationBuilder"/></returns>
    public static IApplicationBuilder UseComponent(this IApplicationBuilder app, IWebHostEnvironment env, Type componentType, object options = default)
    {
        // 创建组件依赖链
        var componentContextLinkList = Penetrates.CreateDependLinkList(componentType, options);

        // 逐条创建组件实例并调用
        foreach (var componentContext in componentContextLinkList)
        {
            // 创建组件实例
            var component = Activator.CreateInstance(componentContext.ComponentType) as IApplicationComponent;

            // 调用
            component.Load(app, env, componentContext);
        }

        return app;
    }
}