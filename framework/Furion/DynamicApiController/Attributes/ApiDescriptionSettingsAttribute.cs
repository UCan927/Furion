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

using Furion.DynamicApiController;

namespace Microsoft.AspNetCore.Mvc;

/// <summary>
/// 接口描述设置
/// </summary>
[SuppressSniffer, AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public sealed class ApiDescriptionSettingsAttribute : ApiExplorerSettingsAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public ApiDescriptionSettingsAttribute() : base()
    {
        Order = 0;
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="enabled">是否启用</param>
    public ApiDescriptionSettingsAttribute(bool enabled) : base()
    {
        IgnoreApi = !enabled;
        Order = 0;
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="groups">分组列表</param>
    public ApiDescriptionSettingsAttribute(params string[] groups) : base()
    {
        GroupName = string.Join(Penetrates.GroupSeparator, groups);
        Groups = groups;
        Order = 0;
    }

    /// <summary>
    /// 自定义名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 保留原有名称（Boolean 类型）
    /// </summary>
    public object KeepName { get; set; }

    /// <summary>
    /// 切割骆驼命名（Boolean 类型）
    /// </summary>
    public object SplitCamelCase { get; set; }

    /// <summary>
    /// 小驼峰命名（首字符小写）
    /// </summary>
    public object AsLowerCamelCase { get; set; }

    /// <summary>
    /// 保留路由谓词（Boolean 类型）
    /// </summary>
    public object KeepVerb { get; set; }

    /// <summary>
    /// 小写路由（Boolean 类型）
    /// </summary>
    public object LowercaseRoute { get; set; }

    /// <summary>
    /// 模块名
    /// </summary>
    public string Module { get; set; }

    /// <summary>
    /// 版本号
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// 分组
    /// </summary>
    public string[] Groups { get; set; }

    /// <summary>
    /// 标签
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// 配置控制器区域（只对控制器有效）
    /// </summary>
    public string Area { get; set; }

    /// <summary>
    /// 额外描述，支持 HTML
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 强制携带路由前缀，即使使用 [Route] 重写，仅对 Class/Controller 有效
    /// </summary>
    public object ForceWithRoutePrefix { get; set; }
}