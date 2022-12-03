using FNATemplate.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FNATemplate.Input
{
    public class PlayerInput
    {
        private static KeyboardState _keyboardState => Keyboard.GetState();
        private static MouseState _mouseState => Mouse.GetState();
        private static GamePadState _padState => GamePad.GetState(PlayerIndex.One);
        private KeyboardState keyboardPrev { get; set; }
        private MouseState mousePrev { get; set; }
        private GamePadState gpPrev { get; set; }

        private List<string> activeActions;

        public readonly Dictionary<Keys, string> KeyMap = new()
        {
            { Keys.W, Actions.MoveUp },
            { Keys.A, Actions.MoveLeft },
            { Keys.S, Actions.MoveDown },
            { Keys.D, Actions.MoveRight }
        };

        public PlayerInput()
        {
            keyboardPrev = new();
            mousePrev = new();
            gpPrev = new();
            activeActions = new();
        }
        public void Update()
        {
            var kbs = _keyboardState;
            activeActions.Clear();

            foreach (var key in kbs.GetPressedKeys())
            {
                if (KeyMap.ContainsKey(key))
                {
                    activeActions.Add(KeyMap[key]);
                }
            }

            // Current is now previous!
            keyboardPrev = kbs;
            mousePrev = _mouseState;
            gpPrev = _padState;
        }

        public bool IsNewKeypress(Keys key)
        {
            KeyboardState keyboardCur = Keyboard.GetState();
            return keyboardCur.IsKeyDown(key) && keyboardPrev.IsKeyUp(key);
        }

        public List<string> GetActiveActions() 
        {
            return activeActions;
        }
    }
}