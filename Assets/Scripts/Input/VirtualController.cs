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

    public struct InputDirection
    {
        public DirectionNotaton notation;
        public Vector2Int direction;
        public float heldTime;
    }

    public class VirtualController
    {
        #region Variables
        private XboxController m_ControllerId;

        private VirtualButton[] m_Buttons;
        private float[] m_ButtonHeldTimes;
        private ButtonState[] m_ButtonStates;
        private IsButtonPressed[] m_ButtonsPressed;
        private InputDirection m_InputDirection;
        //private DirectionNotaton m_PreInputDirection;
        

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

        public IsButtonPressed GetIsButtonPressed(VButton button)
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
        #endregion

        #region Initialization 
        private void Init()
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

            switch (m_ControllerId)
            {
                case XboxController.First:

                    m_Buttons = new VirtualButton[(int)VButton.BUTTONS_MAX]
                    {
                         new VirtualButton(m_ControllerId, KeyCode.W, XboxButton.DPadUp, new AxisToButton(m_ControllerId,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.S, XboxButton.DPadDown, new AxisToButton(m_ControllerId,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.A, XboxButton.DPadLeft, new AxisToButton(m_ControllerId,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.D, XboxButton.DPadRight, new AxisToButton(m_ControllerId,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.U, XboxButton.X),
                         new VirtualButton(m_ControllerId, KeyCode.I, XboxButton.Y),
                         new VirtualButton(m_ControllerId, KeyCode.O, XboxButton.RightBumper),
                         new VirtualButton(m_ControllerId, KeyCode.J, XboxButton.A),
                         new VirtualButton(m_ControllerId, KeyCode.K, XboxButton.B),
                         new VirtualButton(m_ControllerId, KeyCode.L,  new AxisToButton(m_ControllerId,XboxAxis.RightTrigger,AxisToButton.ReadAxis.Positive,0.0f))
                    };
                    break;

                case XboxController.Second:

                    m_Buttons = new VirtualButton[(int)VButton.BUTTONS_MAX]
                    {
                         new VirtualButton(m_ControllerId, KeyCode.UpArrow, XboxButton.DPadUp, new AxisToButton(m_ControllerId,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.DownArrow, XboxButton.DPadDown, new AxisToButton(m_ControllerId,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.LeftArrow, XboxButton.DPadLeft, new AxisToButton(m_ControllerId,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.RightArrow, XboxButton.DPadRight, new AxisToButton(m_ControllerId,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.Keypad7, XboxButton.X),
                         new VirtualButton(m_ControllerId, KeyCode.Keypad8, XboxButton.Y),
                         new VirtualButton(m_ControllerId, KeyCode.Keypad9, XboxButton.RightBumper),
                         new VirtualButton(m_ControllerId, KeyCode.Keypad4, XboxButton.A),
                         new VirtualButton(m_ControllerId, KeyCode.Keypad5, XboxButton.B),
                         new VirtualButton(m_ControllerId, KeyCode.Keypad6, new AxisToButton(m_ControllerId,XboxAxis.RightTrigger,AxisToButton.ReadAxis.Positive,0.0f))
                    };
                    break;

                default:

                    m_Buttons = new VirtualButton[(int)VButton.BUTTONS_MAX]
                    {
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.DPadUp, new AxisToButton(m_ControllerId,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.DPadDown, new AxisToButton(m_ControllerId,XboxAxis.LeftStickY,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.DPadLeft, new AxisToButton(m_ControllerId,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Negative,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.DPadRight, new AxisToButton(m_ControllerId,XboxAxis.LeftStickX,AxisToButton.ReadAxis.Positive,0.5f)),
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.X),
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.Y),
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.RightBumper),
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.A),
                         new VirtualButton(m_ControllerId, KeyCode.None, XboxButton.B),
                         new VirtualButton(m_ControllerId, KeyCode.None, new AxisToButton(m_ControllerId,XboxAxis.RightTrigger,AxisToButton.ReadAxis.Positive,0.0f))
                    };
                    break;

            }
        }
        #endregion

        #region Update
        //5+(raw horizontal axis)+(3*raw vertical axis)
        private InputDirection SetDirection()
        {
            m_InputDirection.notation = DirectionNotaton.Neutral;
            m_InputDirection.direction = Vector2Int.zero;

            int up = (int)GetIsButtonPressed(VButton.Up);
            int down = (int)GetIsButtonPressed(VButton.Down);
            int left = (int)GetIsButtonPressed(VButton.Left);
            int right = (int)GetIsButtonPressed(VButton.Right);

            m_InputDirection.notation += (right - left) + (3 * (up - down));
            m_InputDirection.direction.x = (right - left);
            m_InputDirection.direction.y = (up - down);

            //m_InputDirection.heldTime += Time.deltaTime;

            ////if current direction is different from previous direction? restart timer
            //if (m_InputDirection.notation != m_PreInputDirection)
            //{
            //    m_InputDirection.heldTime = Time.deltaTime;
            //}

            ////store held direction of previous frames 
            //m_PreInputDirection = m_InputDirection.notation;

            return InputDirection;
        }

        private void UpdateButtons()
        {
            for (int i = 0; i < m_Buttons.Length; i++)
            {
                //Reset button states for the start of current frame;
                m_ButtonStates[i] = ButtonState.None;
                m_ButtonsPressed[i] = IsButtonPressed.None;

                

                //Update axis to check for delta's
                if (m_Buttons[i].Axis != null)
                {
                    m_Buttons[i].Axis.Update();
                }
            
                //Update held times for each button
                if (GetIsButtonPressed((VButton)i) == IsButtonPressed.IsPressed)
                {
                    m_ButtonHeldTimes[i] += Time.deltaTime;
                }
                else
                {
                    m_ButtonHeldTimes[i] = 0;
                }
            }
            
            // update InputDirection
            SetDirection();
        }

        #endregion

        public VirtualController(XboxController controllerId)
        {
            m_ControllerId = controllerId;
            Init();
        }

        public void Update()
        {
            UpdateButtons();
        }
    }
}
