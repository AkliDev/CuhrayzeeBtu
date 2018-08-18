using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public enum ButtonState
{
    Released = -1,
    NotPressed = 0,
    Down = 1,
    Held = 2,
};

namespace GameInput
{
    public class VirtualButton
    {
        private VirtualController m_Controller;

        //private XboxAxis m_Axis = XboxAxis.None;
        private XboxButton m_Button = XboxButton.None;
        private KeyCode m_Key = KeyCode.None;

        public VirtualController Controller { get { return m_Controller; } set { m_Controller = value; } }

        //public XboxAxis Axis { get { return m_Axis; } set { m_Axis = value; } }
        public XboxButton Button { get { return m_Button; } set { m_Button = value; } }
        public KeyCode Key { get { return m_Key; } set { m_Key = value; } }

        public VirtualButton(VirtualController controller)
        {
            Controller = controller;
        }

        //public VirtualButton(XboxAxis axis)
        //{
        //    Axis = axis;
        //}

        public VirtualButton(VirtualController controller, KeyCode key)
        {
            Controller = controller;
            Key = key;
        }

        public VirtualButton(VirtualController controller, KeyCode key, XboxButton button)
        {
            Controller = controller;
            Key = key;
            Button = button;
        }

        public VirtualButton(VirtualController controller, XboxButton button)
        {
            Controller = controller;
            Button = button;
        }

        public ButtonState GetButtonState()
        {
            //if (m_Axis != XboxAxis.None)
            //{

            //}

            if (m_Button != XboxButton.None)
            {
                if (XCI.GetButtonDown(m_Button, m_Controller.ControllerID)) { return ButtonState.Down; }
                if (XCI.GetButton(m_Button, m_Controller.ControllerID)) { return ButtonState.Held; }
                if (XCI.GetButtonUp(m_Button, m_Controller.ControllerID)) { return ButtonState.Released; }
            }

            if (m_Key != KeyCode.None)
            {
                if (Input.GetKeyDown(m_Key)) return ButtonState.Down;
                if (Input.GetKey(m_Key)) return ButtonState.Held;
                if (Input.GetKeyUp(m_Key)) return ButtonState.Released;
            }

            return ButtonState.NotPressed;
        }
    }
}
