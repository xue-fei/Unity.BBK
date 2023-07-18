using System;
using System.Collections.Generic;
using BBKRPGSimulator.Graphics;
using BBKRPGSimulator.View;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace BBKRPGSimulator
{
    /// <summary>
    /// RPG模拟器
    /// </summary>
    public class RPGSimulator : MonoBehaviour
    {
        #region 事件

        /// <summary>
        /// 请求退出
        /// </summary>
        public event EventHandler ExitRequested;

        /// <summary>
        /// 帧所有画面绘制完成，输出画面
        /// </summary>
        public event Action<ImageBuilder> RenderFrame;

        #endregion 事件

        #region 字段

        private SimulatorContext _context;

        /// <summary>
        /// 键映射
        /// </summary>
        private Dictionary<int, int> _keyMap = new Dictionary<int, int>();

        /// <summary>
        /// 主画布
        /// </summary>
        private ICanvas _mainCanvas = null;

        #endregion 字段

        #region 属性

        private bool start = false;
        #endregion 属性

        #region 构造函数

        /// <summary>
        /// RPG模拟器
        /// </summary>
        public RPGSimulator()
        { }

        #endregion 构造函数

        #region 方法

        /// <summary>
        /// 按键按下
        /// </summary>
        /// <param name="keyCode"></param>
        public void KeyPressed(int keyCode)
        {
            //int key = GetKey(keyCode);
            _context.KeyPressed(keyCode);
        }

        /// <summary>
        /// 按键放开
        /// </summary>
        /// <param name="keyCode"></param>
        public void KeyReleased(int keyCode)
        {
            //int key = GetKey(keyCode);
            //_context.PlayContext?.PlayerCharacter?.GainExperience(1000);
            _context.KeyReleased(keyCode);
        }

        /// <summary>
        /// 启动游戏
        /// </summary>
        public void Launch(SimulatorOptions options)
        {
            _context = new SimulatorContext(this, options);

            if (options.KeyMap?.Count > 0)
            {
                foreach (var item in options.KeyMap)
                {
                    if (!_keyMap.ContainsKey(item.Key))
                    {
                        _keyMap.Add(item.Key, item.Value);
                    }
                }
            }
            _mainCanvas = _context.GraphicsFactory.NewCanvas();

            _context.PushScreen(new ScreenAnimation(_context, 247));

            start = true;
        }

        /// <summary>
        /// 停止运行
        /// </summary>
        public void Stop()
        {
            start = false;
        }

        /// <summary>
        /// 请求退出
        /// </summary>
        internal void InvokeExitRequest()
        {
            ExitRequested?.Invoke(this, EventArgs.Empty);
        }

        #region Internal

        long curTime;
        long lastTime;
        /// <summary>
        /// 游戏运行的主线程
        /// </summary>
        private void Update()
        {
            if (start)
            {
                curTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                if (curTime - lastTime > _context.LoopInterval)
                {
                    try
                    {
                        lock (_context.ScreenStack)
                        {
                            curTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                            _context.ScreenStack.Peek().Update(curTime - lastTime);
                            lastTime = curTime;

                            // 刷新
                            for (int i = 0; i < _context.ScreenStack.Count; i++)
                            {
                                _context.ScreenStack[i].Draw(_mainCanvas);
                            }

                            RenderFrame?.Invoke(_mainCanvas.Background);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.LogException(ex);
                    }
                }
            }
        }

        #endregion Internal

        #endregion 方法
    }
}