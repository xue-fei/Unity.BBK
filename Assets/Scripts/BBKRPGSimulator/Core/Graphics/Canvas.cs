using System;
using System.Drawing;

namespace BBKRPGSimulator.Graphics
{
    /// <summary>
    /// ����
    /// </summary>
    internal class Canvas : ICanvas
    {
        #region �ֶ�

        /// <summary>
        /// ��ǰ��������
        /// </summary>
        public ImageBuilder Background { get; private set; }

        #endregion �ֶ�

        #region ���캯��

        /// <summary>
        /// �½����������ñ���
        /// </summary>
        /// <param name="bitmap"></param>
        internal Canvas(ImageBuilder bitmap)
        {
            Background = bitmap;
        }

        #endregion ���캯��

        #region ����

        /// <summary>
        /// ����ͼ��
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void DrawBitmap(ImageBuilder bitmap, int left, int top)
        {
            Background.Draw(bitmap, left, top);
        }

        /// <summary>
        /// �����ɫ
        /// </summary>
        /// <param name="color"></param>
        public void DrawColor(int color)
        {
            Background.FillRectangle(color, 0, 0, Background.Width, Background.Height);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="stopX"></param>
        /// <param name="stopY"></param>
        /// <param name="paint"></param>
        public void DrawLine(int startX, int startY, int stopX, int stopY, Paint paint)
        {
            Background.DrawLine(paint.Color, startX, startY, stopX, stopY);
        }

        /// <summary>
        /// ���������߶Σ�����
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="paint"></param>
        public void DrawLines(float[] pts, Paint paint)
        {
            int size = pts.Length / 4;
            for (int i = 0; i < size; i++)
            {
                Background.DrawLine(paint.Color, (int)pts[i * 4], (int)pts[(i * 4) + 1], (int)pts[(i * 4) + 2], (int)pts[((i * 4)) + 3]);
            }
        }

        /// <summary>
        /// ���ƾ���
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="paint"></param>
        public void DrawRect(int left, int top, int right, int bottom, Paint paint)
        {
            DrawRectangle(left, top, right - left, bottom - top, paint);
        }

        /// <summary>
        /// ���ƾ���
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="pait"></param>
        public void DrawRect(Rectangle rectangle, Paint pait)
        {
            DrawRectangle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, pait);
        }

        /// <summary>
        /// ���Ż���
        /// </summary>
        /// <param name="mScale"></param>
        /// <param name="mScale2"></param>
        public void Scale(float mScale, float mScale2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ���û�������
        /// </summary>
        /// <param name="bitmap"></param>
        public void SetBitmap(ImageBuilder bitmap)
        {
            Background = bitmap;
        }

        /// <summary>
        /// ���ƾ���
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="paint"></param>
        private void DrawRectangle(int left, int top, int width, int height, Paint paint)
        {
            if (paint.Style == PaintStyle.FILL)
            {
                Background.FillRectangle(paint.Color, left, top, width, height);
            }
            else if (paint.Style == PaintStyle.STROKE)
            {
                Background.DrawRectangle(paint.Color, left, top, width, height);
            }
            else
            {
                Background.FillRectangle(paint.Color, left, top, width, height);
            }
        }

        #endregion ����
    }
}