using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace GameInput
{
    public enum Button
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
        Button6

    }
    public class VirtualController
    {
        private XboxController m_ControllerID;

        private VirtualButton[] m_Buttons;

        public XboxController ControllerID { get { return m_ControllerID; } set { m_ControllerID = value; } }

        public VirtualButton GetButton(Button button)
        {
            return m_Buttons[(int)button];
        }

        private void SetDefaultButtons()
        {

            switch (m_ControllerID)
            {
                case XboxController.First:

                    m_Buttons = new VirtualButton[10]
                    {
                         new VirtualButton(this, KeyCode.W, XboxButton.DPadUp),
                         new VirtualButton(this, KeyCode.S, XboxButton.DPadDown),
                         new VirtualButton(this, KeyCode.A, XboxButton.DPadLeft),
                         new VirtualButton(this, KeyCode.D, XboxButton.DPadRight),
                         new VirtualButton(this, KeyCode.T, XboxButton.X),
                         new VirtualButton(this, KeyCode.Y, XboxButton.Y),
                         new VirtualButton(this, KeyCode.U, XboxButton.RightBumper),
                         new VirtualButton(this, KeyCode.F, XboxButton.A),
                         new VirtualButton(this, KeyCode.G, XboxButton.B),
                         new VirtualButton(this, KeyCode.H, XboxButton.LeftBumper)
                    };
                    break;

                case XboxController.Second:

                    m_Buttons = new VirtualButton[10]
                    {
                         new VirtualButton(this, KeyCode.UpArrow, XboxButton.DPadUp),
                         new VirtualButton(this, KeyCode.DownArrow, XboxButton.DPadDown),
                         new VirtualButton(this, KeyCode.LeftArrow, XboxButton.DPadLeft),
                         new VirtualButton(this, KeyCode.RightArrow, XboxButton.DPadRight),
                         new VirtualButton(this, KeyCode.Keypad7, XboxButton.X),
                         new VirtualButton(this, KeyCode.Keypad8, XboxButton.Y),
                         new VirtualButton(this, KeyCode.Keypad9, XboxButton.RightBumper),
                         new VirtualButton(this, KeyCode.Keypad4, XboxButton.A),
                         new VirtualButton(this, KeyCode.Keypad5, XboxButton.B),
                         new VirtualButton(this, KeyCode.Keypad6, XboxButton.LeftBumper)
                    };
                    break;

                default:

                    m_Buttons = new VirtualButton[10]
                    {
                         new VirtualButton(this, KeyCode.None, XboxButton.DPadUp),
                         new VirtualButton(this, KeyCode.None, XboxButton.DPadDown),
                         new VirtualButton(this, KeyCode.None, XboxButton.DPadLeft),
                         new VirtualButton(this, KeyCode.None, XboxButton.DPadRight),
                         new VirtualButton(this, KeyCode.None, XboxButton.X),
                         new VirtualButton(this, KeyCode.None, XboxButton.Y),
                         new VirtualButton(this, KeyCode.None, XboxButton.RightBumper),
                         new VirtualButton(this, KeyCode.None, XboxButton.A),
                         new VirtualButton(this, KeyCode.None, XboxButton.B),
                         new VirtualButton(this, KeyCode.None, XboxButton.LeftBumper)
                    };
                    break;
            }
        }

        public VirtualController(XboxController controllerID)
        {
            MonoBehaviour.print(controllerID.ToString() + " VirtualController Created");
            ControllerID = controllerID;
            //SetButtonsFromFile();
            SetDefaultButtons();
        }
    }
}
