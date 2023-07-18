using System.Drawing;

using BBKRPGSimulator.Characters;
using BBKRPGSimulator.Graphics;
using BBKRPGSimulator.Graphics.Util;
using BBKRPGSimulator.Magic;

namespace BBKRPGSimulator.View.GameMenu
{
    /// <summary>
    /// ħ��ʹ�ý���
    /// </summary>
    internal class ScreenUseMagic : BaseScreen
    {
        #region ��̬����

        /// <summary>
        /// ���ƿ�
        /// </summary>
        private static readonly Rectangle _nameRect = new Rectangle(4, 4, 33, 92);

        #endregion ��̬����

        #region �ֶ�

        /// <summary>
        /// ��ǰչʾ��״̬ҳ������
        /// </summary>
        private int _curStatePageIndex = 0;

        /// <summary>
        /// Ҫʹ�õ�ħ��
        /// </summary>
        private MagicRestore _magic;

        /// <summary>
        /// ħ��ʹ�ý�ɫ
        /// </summary>
        private PlayerCharacter _magicUser;

        /// <summary>
        /// ��ǰѡ���ɫ����
        /// </summary>
        private int _selectedCharacterIndex = 0;

        #endregion �ֶ�

        #region ���캯��

        /// <summary>
        /// ħ��ʹ�ý���
        /// </summary>
        /// <param name="context"></param>
        /// <param name="magic"></param>
        /// <param name="scr"></param>
        public ScreenUseMagic(SimulatorContext context, MagicRestore magic, PlayerCharacter scr) : base(context)
        {
            _magic = magic;
            _magicUser = scr;
        }

        #endregion ���캯��

        #region ����

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawColor(Constants.COLOR_WHITE);
            TextRender.DrawText(canvas, _magic.Name, 0, _nameRect);
            PlayerCharacter character = Context.PlayContext.PlayerCharacters[_selectedCharacterIndex];
            character.DrawState(canvas, _curStatePageIndex);
            character.DrawHead(canvas, 5, 60);
        }

        public override void OnKeyDown(int key)
        {
            if (key == SimulatorKeys.KEY_RIGHT && _selectedCharacterIndex < Context.PlayContext.PlayerCharacters.Count - 1)
            {
                ++_selectedCharacterIndex;
            }
            else if (key == SimulatorKeys.KEY_LEFT && _selectedCharacterIndex > 0)
            {
                --_selectedCharacterIndex;
            }
            else if (key == SimulatorKeys.KEY_PAGEDOWN || key == SimulatorKeys.KEY_PAGEUP)
            {
                _curStatePageIndex = 1 - _curStatePageIndex;
            }
        }

        public override void OnKeyUp(int key)
        {
            if (key == SimulatorKeys.KEY_CANCEL)
            {
                Context.PopScreen();
            }
            else if (key == SimulatorKeys.KEY_ENTER)
            {
                _magic.Use(_magicUser, Context.PlayContext.PlayerCharacters[_selectedCharacterIndex]);
                Context.PopScreen();
            }
        }

        public override void Update(long delta)
        {
        }

        #endregion ����
    }
}