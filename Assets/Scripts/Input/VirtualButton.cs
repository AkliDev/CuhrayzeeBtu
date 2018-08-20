using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;



namespace GameInput
{
    public enum ButtonState
    {
        None = -2,
        Released = -1,
        NotPressed = 0,
        Down = 1,
        Held = 2,
    };

    public enum IsButtonPressed
    {
        None = -2,
        NotPressed = 0,
        IsPressed = 1
    };

    public class VirtualButton
    {
        private XboxController m_ControllerId;

        private XboxButton m_Button = XboxButton.None;
        private KeyCode m_Key = KeyCode.None;
        private AxisToButton m_Axis;

        public AxisToButton Axis { get { return m_Axis; } }

        public VirtualButton(XboxController controller)
        {
            m_ControllerId = controller;
        }

        public VirtualButton(XboxController controller, KeyCode key)
        {
            m_ControllerId = controller;
            m_Key = key;
        }

        public VirtualButton(XboxController controller, XboxButton button)
        {
            m_ControllerId = controller;
            m_Button = button;
        }

        public VirtualButton(XboxController controller, AxisToButton axis)
        {
            m_ControllerId = controller;
            m_Axis = axis;
        }

        public VirtualButton(XboxController controller, KeyCode key, XboxButton button)
        {
            m_ControllerId = controller;
            m_Key = key;
            m_Button = button;
        }

        public VirtualButton(XboxController controller, KeyCode key, AxisToButton axis)
        {
            m_ControllerId = controller;
            m_Key = key;
            m_Axis = axis;
        }

        public VirtualButton(XboxController controller, XboxButton button, AxisToButton axis)
        {
            m_ControllerId = controller;
            m_Button = button;
            m_Axis = axis;
        }

        public VirtualButton(XboxController controller, KeyCode key, XboxButton button, AxisToButton axis)
        {
            m_ControllerId = controller;
            m_Key = key;
            m_Button = button;
            m_Axis = axis;
        }

        public ButtonState GetButtonState()
        {
            if (m_Button != XboxButton.None)
                if (XCI.GetButton(m_Button, m_ControllerId)) return ButtonState.Held;
            if (m_Axis != null)
                if (m_Axis.State == ButtonState.Held) return ButtonState.Held;
            if (m_Key != KeyCode.None)
                if (Input.GetKey(m_Key)) return ButtonState.Held;

            if (m_Button != XboxButton.None)
                if (XCI.GetButtonDown(m_Button, m_ControllerId)) return ButtonState.Down;
            if (m_Axis != null)
                if (m_Axis.State == ButtonState.Down) return ButtonState.Down;
            if (m_Key != KeyCode.None)
                if (Input.GetKeyDown(m_Key)) return ButtonState.Down;

            if (m_Button != XboxButton.None)
                if (XCI.GetButtonUp(m_Button, m_ControllerId)) return ButtonState.Released;
            if (m_Axis != null)
                if (m_Axis.State == ButtonState.Released) return ButtonState.Released;
            if (m_Key != KeyCode.None)
                if (Input.GetKeyUp(m_Key)) return ButtonState.Released;

            return ButtonState.NotPressed;
        }
    }
}
