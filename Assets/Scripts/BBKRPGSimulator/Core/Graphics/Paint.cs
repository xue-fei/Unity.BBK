namespace BBKRPGSimulator.Graphics
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class Paint
    {
        #region ����

        /// <summary>
        /// ��ɫ
        /// </summary>
        public int Color { get; private set; }

        /// <summary>
        /// �������
        /// </summary>
        public int StrokeWidth { get; set; } = 0;

        /// <summary>
        /// ���Ʒ��
        /// </summary>
        public PaintStyle Style { get; private set; }

        #endregion ����

        #region ���캯��

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public Paint()
        {
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="style"></param>
        public Paint(PaintStyle style)
        {
            Style = style;
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="colorValue"></param>
        public Paint(int colorValue)
        {
            Color = colorValue;
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="style"></param>
        /// <param name="colorValue"></param>
        public Paint(PaintStyle style, int colorValue)
        {
            Style = style;
            Color = colorValue;
        }

        #endregion ���캯��

        #region ����

        /// <summary>
        /// ������ɫ
        /// </summary>
        /// <param name="colorValue"></param>
        public void SetColor(int colorValue)
        {
            Color = colorValue;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="width"></param>
        public void SetStrokeWidth(int width)
        {
            StrokeWidth = width;
        }

        /// <summary>
        /// ���÷��
        /// </summary>
        /// <param name="style"></param>
        public void SetStyle(PaintStyle style)
        {
            Style = style;
        }

        #endregion ����
    }
}