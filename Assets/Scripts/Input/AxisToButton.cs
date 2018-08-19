using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace GameInput
{
    public class AxisToButton 
    {
        public enum ReadAxis
        {
            None,
            Positive,
            Negative,       
        }

        private XboxController m_ControllerId;
        private XboxAxis m_Axis = XboxAxis.None;
        private ReadAxis m_Readaxis = ReadAxis.None;
        private float m_DeadZone;
        private float m_PreValue;

        public AxisToButton(XboxController controllerId, XboxAxis axis, ReadAxis readAxis, float deadZone)
        {
            m_ControllerId = controllerId;
            m_Axis = axis;
            m_Readaxis = readAxis;
            m_DeadZone = deadZone;
        }

        public void Update()
        {
            m_PreValue = XCI.GetAxisRaw(m_Axis, m_ControllerId);
        }

        //Compares value with previous state to determine what state to return;
        public ButtonState GetState()
        {
            switch (m_Readaxis)
            {
                case ReadAxis.Positive:
                    if (XCI.GetAxisRaw(m_Axis, m_ControllerId) > m_DeadZone && m_PreValue > m_DeadZone) return ButtonState.Held;
                    if (XCI.GetAxisRaw(m_Axis, m_ControllerId) > m_DeadZone && m_PreValue < m_DeadZone) return ButtonState.Down;
                    if (XCI.GetAxisRaw(m_Axis, m_ControllerId) < m_DeadZone && m_PreValue > m_DeadZone) return ButtonState.Released;

                    break;
                case ReadAxis.Negative:
                    if (XCI.GetAxisRaw(m_Axis, m_ControllerId) < -m_DeadZone && m_PreValue < -m_DeadZone) return ButtonState.Held;
                    if (XCI.GetAxisRaw(m_Axis, m_ControllerId) < -m_DeadZone && m_PreValue > -m_DeadZone) return ButtonState.Down;
                    if (XCI.GetAxisRaw(m_Axis, m_ControllerId) > -m_DeadZone && m_PreValue < -m_DeadZone) return ButtonState.Released;
                    break;
            }
           
            return ButtonState.NotPressed;
        }
    }
}
