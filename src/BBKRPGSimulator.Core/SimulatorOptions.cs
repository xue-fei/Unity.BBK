﻿using System.Collections.Generic;
using System.IO;

using BBKRPGSimulator.Graphics;

namespace BBKRPGSimulator
{
    /// <summary>
    /// 模拟器选项
    /// </summary>
    public class SimulatorOptions
    {
        #region Lib数据配置

        /// <summary>
        /// 图片构建器工厂
        /// </summary>
        public IGraphicsFactory GraphicsFactory { get; set; }

        /// <summary>
        /// lib数据
        /// LibPath、LibData、LibStream都配置时，优先级为LibData》LibStream都配置时》LibPath
        /// </summary>
        public byte[] LibData { get; set; }

        /// <summary>
        /// lib位置
        /// LibPath、LibData、LibStream都配置时，优先级为LibData》LibStream都配置时》LibPath
        /// </summary>
        public string LibPath { get; set; }

        /// <summary>
        /// lib流
        /// LibPath、LibData、LibStream都配置时，优先级为LibData》LibStream都配置时》LibPath
        /// </summary>
        public Stream LibStream { get; set; }

        #endregion Lib数据配置

        #region 属性

        /// <summary>
        /// 按键映射
        /// </summary>
        public Dictionary<int, int> KeyMap { get; set; }

        /// <summary>
        /// 处理的循环间隔（毫秒）
        /// 默认45
        /// </summary>
        public int LoopInterval { get; set; } = 45;

        #endregion 属性
    }
}