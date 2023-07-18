using BBKRPGSimulator.Graphics;

namespace BBKRPGSimulator.Script
{
    /// <summary>
    /// ����һ�εĲ�����
    /// </summary>
    internal abstract class OperateDrawScene : Operate
    {
        #region �ֶ�

        /// <summary>
        /// ���Ƽ���
        /// </summary>
        private int _drawCount = 0;

        #endregion �ֶ�

        #region ���캯��

        /// <summary>
        /// ����һ�εĲ�����
        /// </summary>
        /// <param name="context"></param>
        public OperateDrawScene(SimulatorContext context) : base(context)
        {
        }

        #endregion ���캯��

        #region ����

        public override void Draw(ICanvas canvas)
        {
            DrawScene(canvas);
            ++_drawCount;
        }

        public virtual void DrawScene(ICanvas canvas)
        {
            Context.SceneMap.DrawScene(canvas);
        }

        public override bool Update(long delta)
        {
            if (_drawCount >= 3)
            {
                _drawCount = 0;
                return false;
            }
            return true;
        }

        #endregion ����
    }
}