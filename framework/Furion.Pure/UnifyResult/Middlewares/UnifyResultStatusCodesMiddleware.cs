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

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Furion.UnifyResult;

/// <summary>
/// 状态码中间件
/// </summary>
[SuppressSniffer]
public class UnifyResultStatusCodesMiddleware
{
    /// <summary>
    /// 请求委托
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="next"></param>
    public UnifyResultStatusCodesMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// 中间件执行方法
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        // 只有请求错误（短路状态码）和非 WebSocket 才支持规范化处理
        if (context.IsWebSocketRequest()
            || context.Response.StatusCode < 400
            || context.Response.StatusCode == 404) return;

        // 处理规范化结果
        if (!UnifyContext.CheckStatusCodeNonUnify(context, out var unifyResult))
        {
            // 解决刷新 Token 时间和 Token 时间相近问题
            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized
                && context.Response.Headers.ContainsKey("access-token")
                && context.Response.Headers.ContainsKey("x-access-token"))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }

            // 如果 Response 已经完成输出，则禁止写入
            if (context.Response.HasStarted) return;
            await unifyResult.OnResponseStatusCodes(context, context.Response.StatusCode, context.RequestServices.GetService<IOptions<UnifyResultSettingsOptions>>()?.Value);
        }
    }
}