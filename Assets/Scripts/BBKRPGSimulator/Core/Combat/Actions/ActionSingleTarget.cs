using BBKRPGSimulator.Characters;
using BBKRPGSimulator.Combat.Anim;
using BBKRPGSimulator.Graphics;

namespace BBKRPGSimulator.Combat.Actions
{
    /// <summary>
    /// ��Ŀ�궯��
    /// </summary>
    internal abstract class ActionSingleTarget : ActionBase
    {
        #region �ֶ�

        /// <summary>
        /// Ư������
        /// </summary>
        protected RaiseAnimation RaiseAnimation { get; set; }

        /// <summary>
        /// Ŀ��
        /// </summary>
        protected FightingCharacter Target { get; set; }

        #endregion �ֶ�

        #region ���캯��

        /// <summary>
        /// ��Ŀ�궯��
        /// </summary>
        /// <param name="context"></param>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        public ActionSingleTarget(SimulatorContext context, FightingCharacter attacker, FightingCharacter target) : base(context)
        {
            Executor = attacker;
            Target = target;
        }

        #endregion ���캯��

        #region ����

        public override bool IsTargetAlive()
        {
            return Target.IsAlive;
        }

        public override bool IsTargetsMoreThanOne()
        {
            return false;
        }

        public override void PostExecute()
        {
            Target.IsVisiable = Target.IsAlive;
        }

        public void SetTarget(FightingCharacter fc)
        {
            Target = fc;
        }

        public override bool TargetIsMonster()
        {
            return Target is Monster;
        }

        protected override void DrawRaiseAnimation(ICanvas canvas)
        {
            if (RaiseAnimation != null)
            {
                RaiseAnimation.Draw(canvas);
            }
        }

        protected override bool UpdateRaiseAnimation(long delta)
        {
            return RaiseAnimation != null && RaiseAnimation.Update(delta);
        }

        #endregion ����
    }
}