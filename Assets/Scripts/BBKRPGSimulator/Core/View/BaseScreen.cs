using BBKRPGSimulator.Graphics;
using BBKRPGSimulator.Graphics.Util;

namespace BBKRPGSimulator.View
{
    /// <summary>
    /// ����Screen
    /// </summary>
    internal abstract class BaseScreen : ContextDependent
    {
        #region ����

        /// <summary>
        /// �ı�������
        /// </summary>
        public TextRender TextRender => Context.TextRender;

        #endregion ����

        #region ���캯��

        /// <summary>
        /// ����Screen
        /// </summary>
        /// <param name="context"></param>
        public BaseScreen(SimulatorContext context) : base(context)
        { }

        #endregion ���캯��

        #region ����

        /// <summary>
        /// ����ǰ��Ļ���Ƶ�ָ��canvas��
        /// </summary>
        /// <param name="canvas"></param>
        public abstract void Draw(ICanvas canvas);

        /// <summary>
        /// �Ƿ񵯳�
        /// </summary>
        /// <returns></returns>
        public virtual bool IsPopup()
        {
            return false;
        }

        /// <summary>
        /// ���¼�
        /// </summary>
        /// <param name="key"></param>
        public abstract void OnKeyDown(int key);

        /// <summary>
        /// �ſ���
        /// </summary>
        /// <param name="key"></param>
        public abstract void OnKeyUp(int key);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="delta"></param>
        public abstract void Update(long delta);

        #endregion ����
    }
}