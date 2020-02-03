﻿namespace BBKRPGSimulator.Script.Commands
{
    /// <summary>
    /// 测试物品数量命令
    /// </summary>
    internal class CommandTestGoodsNum : BaseCommand
    {
        #region 构造函数

        /// <summary>
        /// 测试物品数量命令
        /// </summary>
        /// <param name="context"></param>
        public CommandTestGoodsNum(SimulatorContext context) : base(context)
        {
        }

        #endregion 构造函数

        #region 方法

        public override int GetNextPos(byte[] code, int start)
        {
            return start + 10;
        }

        public override Operate GetOperate(byte[] code, int start)
        {
            return new CommandTestGoodsNumOperate(Context, code, start);
        }

        #endregion 方法

        #region 类

        /// <summary>
        /// 测试物品数量命令的操作
        /// </summary>
        private class CommandTestGoodsNumOperate : OperateAdapter
        {
            #region 字段

            private byte[] _code;
            private int _start;

            #endregion 字段

            #region 构造函数

            /// <summary>
            /// 测试物品数量命令的操作
            /// </summary>
            /// <param name="context"></param>
            /// <param name="code"></param>
            /// <param name="start"></param>
            public CommandTestGoodsNumOperate(SimulatorContext context, byte[] code, int start) : base(context)
            {
                _code = code;
                _start = start;
            }

            #endregion 构造函数

            #region 方法

            public override bool Process()
            {
                int goodsnum = Context.GoodsManage.GetGoodsNum(_code.Get2BytesUInt(_start), _code.Get2BytesUInt(_start + 2));
                int num = _code.Get2BytesUInt(_start + 4);
                if (goodsnum == num)
                {
                    Context.ScriptProcess.GotoAddress(_code.Get2BytesUInt(_start + 6));
                }
                else if (goodsnum > num)
                {
                    Context.ScriptProcess.GotoAddress(_code.Get2BytesUInt(_start + 8));
                }
                return false;
            }

            #endregion 方法
        }

        #endregion 类
    }
}