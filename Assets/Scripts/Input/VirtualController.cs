using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;



namespace GameInput
{
    public enum VButton
    {
        Up,
        Down,
        Left,
        Right,
        Button1,
        Button2,
        Button3,
        Button4,
        Button5,
        Button6,
        BUTTONS_MAX
    }

    public enum DirectionNotaton
    {
        DownLeft = 1,
        Down = 2,
        DownRight = 3,
        Left = 4,
        Neutral = 5,
        Right = 6,
        UpLeft = 7,
        Up = 8,
        UpRight = 9,
    }

    public class InputDirection
    {
        public DirectionNotaton notation = DirectionNotaton.Neutral;
        public Vector2 direction = Vector2.zero;
    }

    public class VirtualController
    {
        private XboxController m_ControllerID;

        private VirtualButton[] m_Buttons;
        private float[] m_ButtonHeldTimes;
        private ButtonState[] m_ButtonStates;
        private IsButtonPressed[] m_ButtonsPressed;
        private InputDirection m_InputDirection;
        private DirectionNotaton m_PreInputDirection;

        public XboxController ControllerID { get { return m_ControllerID; } set { m_ControllerID = value; } }
        public InputDirection InputDirection { get { return m_InputDirection; } }

        public float GetButtonHeldTime(VButton button)
        {
            return m_ButtonHeldTimes[(int)button];
        }

        public ButtonState GetButtonState(VButton button)
        {
            if (m_ButtonStates[(int)button] != ButtonState.None)
                return m_ButtonStates[(int)button];

            m_ButtonStates[(int)button] = m_Buttons[(int)button].GetButtonState();
            return m_ButtonStates[(int)button];
        }

        public IsButtonPressed CheckIsButtonPressed(VButton button)
        {
            if (m_ButtonsPressed[(int)button] != IsButtonPressed.None)
                return m_ButtonsPressed[(int)button];

            switch (GetButtonState(button))
            {
                case ButtonState.Held:
                    m_ButtonsPressed[(int)button] = IsButtonPressed.IsPressed;
                    return m_ButtonsPressed[(int)button];

                case ButtonState.Down:
                    m_ButtonsPressed[(int)button] = IsButtonPressed.IsPressed;
                    return m_ButtonsPressed[(int)button];

                default:
                    m_ButtonsPressed[(int)button] = IsButtonPressed.NotPressed;
                    return m_ButtonsPressed[(int)button];
            }
        }

        private void init()
        {
            m_InputDirection = new InputDirection();
            SetDefaultButtons();  //SetButtonsFromFile();
            m_ButtonHeldTimes = new float[m_Buttons.Length];
            m_ButtonStates = new ButtonState[m_Buttons.Length];
            m_ButtonsPressed = new IsButtonPressed[m_Buttons.Length];
        }

        //sets default button configuration for all controllers
        private void SetDefaultButtons()
        {

            switch (m_ControllerID)
            {
                case XboxController.First:

                    m_Buttons = new VirtualButton[(int)VButton.BUTTONS_MAX]
                    {
                         new VirtualButton(m_ControllerID, KeyCode.W, XboxButton.DPadUp, new AxisToButton(m_ControllerID,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.S, XboxButton.DPadDown, new AxisToButton(m_ControllerID,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.A, XboxButton.DPadLeft, new AxisToButton(m_ControllerID,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.D, XboxButton.DPadRight, new AxisToButton(m_ControllerID,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.U, XboxButton.X),
                         new VirtualButton(m_ControllerID, KeyCode.I, XboxButton.Y),
                         new VirtualButton(m_ControllerID, KeyCode.O, XboxButton.RightBumper),
                         new VirtualButton(m_ControllerID, KeyCode.J, XboxButton.A),
                         new VirtualButton(m_ControllerID, KeyCode.K, XboxButton.B),
                         new VirtualButton(m_ControllerID, KeyCode.L,  new AxisToButton(m_ControllerID,XboxAxis.RightTrigger,AxisToButton.ReadAxis.Positive,0.0f))
                    };
                    break;

                case XboxController.Second:

                    m_Buttons = new VirtualButton[(int)VButton.BUTTONS_MAX]
                    {
                         new VirtualButton(m_ControllerID, KeyCode.UpArrow, XboxButton.DPadUp, new AxisToButton(m_ControllerID,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.DownArrow, XboxButton.DPadDown, new AxisToButton(m_ControllerID,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.LeftArrow, XboxButton.DPadLeft, new AxisToButton(m_ControllerID,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.RightArrow, XboxButton.DPadRight, new AxisToButton(m_ControllerID,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.Keypad7, XboxButton.X),
                         new VirtualButton(m_ControllerID, KeyCode.Keypad8, XboxButton.Y),
                         new VirtualButton(m_ControllerID, KeyCode.Keypad9, XboxButton.RightBumper),
                         new VirtualButton(m_ControllerID, KeyCode.Keypad4, XboxButton.A),
                         new VirtualButton(m_ControllerID, KeyCode.Keypad5, XboxButton.B),
                         new VirtualButton(m_ControllerID, KeyCode.Keypad6, new AxisToButton(m_ControllerID,XboxAxis.RightTrigger,AxisToButton.ReadAxis.Positive,0.0f))
                    };
                    break;

                default:

                    m_Buttons = new VirtualButton[(int)VButton.BUTTONS_MAX]
                    {
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.DPadUp, new AxisToButton(m_ControllerID,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.DPadDown, new AxisToButton(m_ControllerID,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.DPadLeft, new AxisToButton(m_ControllerID,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.DPadRight, new AxisToButton(m_ControllerID,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.X),
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.Y),
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.RightBumper),
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.A),
                         new VirtualButton(m_ControllerID, KeyCode.None, XboxButton.B),
                         new VirtualButton(m_ControllerID, KeyCode.None, new AxisToButton(m_ControllerID,XboxAxis.RightTrigger,AxisToButton.ReadAxis.Positive,0.0f))
                    };
                    break;

            }
        }

        private void UpdateButtons()
        {
            for (int i = 0; i < m_Buttons.Length; i++)
            {
                // reset button states for the current frame;
                m_ButtonStates[i] = ButtonState.None;
                m_ButtonsPressed[i] = IsButtonPressed.None;

                //update axis to check for delta's
                if (m_Buttons[i].Axis != null)
                {
                    m_Buttons[i].Axis.Update();
                }

                //Update held times for each button
                if (CheckIsButtonPressed((VButton)i) == IsButtonPressed.IsPressed)
                {
                    m_ButtonHeldTimes[i] += Time.deltaTime;
                }
                else
                {
                    m_ButtonHeldTimes[i] = 0;
                }
            }
        }

        public VirtualController(XboxController controllerID)
        {
            ControllerID = controllerID;
            init();
        }

        //5+(raw horizontal axis)+(3*raw vertical axis)
        public InputDirection GetDirection()
        {
            m_InputDirection.notation = DirectionNotaton.Neutral;
            m_InputDirection.direction = Vector2.zero;

            int up = (int)CheckIsButtonPressed(VButton.Up);
            int down = (int)CheckIsButtonPressed(VButton.Down);
            int left = (int)CheckIsButtonPressed(VButton.Left);
            int right = (int)CheckIsButtonPressed(VButton.Right);

            m_InputDirection.notation += (right - left) + (3 * (up - down));
            m_InputDirection.direction.x = (right - left);
            m_InputDirection.direction.y = (up - down);

            return InputDirection;
        }

        public void Update()
        {
            UpdateButtons();
        }
    }
}
