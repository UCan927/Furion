﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             http://license.coscl.org.cn/MulanPSL2
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.DependencyInjection;
using Furion.UnifyResult;
using System;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// 状态码中间件拓展
    /// </summary>
    [SuppressSniffer]
    public static class UnifyResultMiddlewareExtensions
    {
        /// <summary>
        /// 添加状态码拦截中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="optionsBuilder"></param>
        /// <param name="intercept404StatusCodes">是否拦截 404 状态码</param>
        /// <returns></returns>
        public static IApplicationBuilder UseUnifyResultStatusCodes(this IApplicationBuilder builder, Action<UnifyResultStatusCodesOptions> optionsBuilder = default, bool intercept404StatusCodes = false)
        {
            // 获取配置
            var unifyResultStatusCodesOptions = new UnifyResultStatusCodesOptions();
            optionsBuilder?.Invoke(unifyResultStatusCodesOptions);

            // 注册中间件
            builder.UseMiddleware<UnifyResultStatusCodesMiddleware>(unifyResultStatusCodesOptions, intercept404StatusCodes);

            return builder;
        }
    }
}