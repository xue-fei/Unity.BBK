namespace BBKRPGSimulator.Script.Commands
{
    /// <summary>
    /// 禁用存档命令
    /// </summary>
    internal class CommandDisableSave : BaseCommand
    {
        #region 构造函数

        /// <summary>
        /// 禁用存档命令
        /// </summary>
        /// <param name="context"></param>
        public CommandDisableSave(SimulatorContext context) : base(0, context)
        {
        }

        #endregion 构造函数

        #region 方法

        protected override Operate ProcessAndGetOperate()
        {
            Context.PlayContext.DisableSave = true;
            return null;
        }

        #endregion 方法
    }
}