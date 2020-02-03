﻿namespace BBKRPGSimulator.Script.Commands
{
    /// <summary>
    /// 创建NPC命令
    /// </summary>
    internal class CommandCreateNpc : BaseCommand
    {
        #region 构造函数

        /// <summary>
        /// 创建NPC命令
        /// </summary>
        /// <param name="context"></param>
        public CommandCreateNpc(SimulatorContext context) : base(context)
        {
        }

        #endregion 构造函数

        #region 方法

        public override int GetNextPos(byte[] code, int start)
        {
            return start + 8;
        }

        public override Operate GetOperate(byte[] code, int start)
        {
            return new CommandCreateNpcOperate(Context, code, start);
        }

        #endregion 方法

        #region 类

        /// <summary>
        /// 创建NPC命令的操作
        /// </summary>
        private class CommandCreateNpcOperate : OperateAdapter
        {
            #region 字段

            private byte[] _code;
            private int _start;

            #endregion 字段

            #region 构造函数

            /// <summary>
            /// 创建NPC命令的操作
            /// </summary>
            /// <param name="context"></param>
            /// <param name="code"></param>
            /// <param name="start"></param>
            public CommandCreateNpcOperate(SimulatorContext context, byte[] code, int start) : base(context)
            {
                _code = code;
                _start = start;
            }

            #endregion 构造函数

            #region 方法

            public override bool Process()
            {
                Context.SceneMap.CreateNpc(_code.Get2BytesUInt(_start),
                        _code.Get2BytesUInt(_start + 2),
                        _code.Get2BytesUInt(_start + 4),
                        _code.Get2BytesUInt(_start + 6));
                return false;
            }

            #endregion 方法
        }

        #endregion 类
    }
}