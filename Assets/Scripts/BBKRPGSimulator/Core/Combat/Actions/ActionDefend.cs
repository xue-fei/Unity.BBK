using BBKRPGSimulator.Characters;
using BBKRPGSimulator.Graphics;

namespace BBKRPGSimulator.Combat.Actions
{
    /// <summary>
    /// ��������
    /// </summary>
    internal class ActionDefend : ActionSingleTarget
    {
        #region ���캯��

        public ActionDefend(SimulatorContext context, FightingCharacter fc) : base(context, fc, null)
        {
        }

        #endregion ���캯��

        #region ����

        public override void Draw(ICanvas canvas)
        {
        }

        public override int GetPriority()
        {
            return base.GetPriority();
        }

        public override bool IsTargetAlive()
        {
            return true;
        }

        public override bool IsTargetsMoreThanOne()
        {
            return false;
        }

        public override void PostExecute()
        {
        }

        public override void PreProccess()
        {
        }

        public override bool TargetIsMonster()
        {
            return true;
        }

        public override string ToString()
        {
            return $"��{Executor.Name}���ķ���";
        }

        public override bool Update(long delta)
        {
            return false;
        }

        #endregion ����
    }
}