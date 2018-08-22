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
        private ButtonState m_State;
        private XboxAxis m_Axis = XboxAxis.None;
        private ReadAxis m_Readaxis = ReadAxis.None;
        private float m_DeadZone;
        private float m_CurrentValue;
        private float m_PreValue;
       

        public ButtonState State { get { return m_State; } }

        public AxisToButton(XboxController controllerId, XboxAxis axis, ReadAxis readAxis, float deadZone)
        {
            m_ControllerId = controllerId;
            m_Axis = axis;
            m_Readaxis = readAxis;
            m_DeadZone = deadZone;
        }

        public void Update()
        {
            m_CurrentValue = XCI.GetAxisRaw(m_Axis, m_ControllerId);
            m_State = SetState();
            m_PreValue = m_CurrentValue;
        }

        //Compares value with previous state to determine what state to return;
        public ButtonState SetState()
        {
            switch (m_Readaxis)
            {        
                case ReadAxis.Positive:
                    if (m_CurrentValue > m_DeadZone && m_PreValue > m_DeadZone) return ButtonState.Held;
                    else if (m_CurrentValue > m_DeadZone && m_PreValue < m_DeadZone) return ButtonState.Down;
                    else if (m_CurrentValue < m_DeadZone && m_PreValue > m_DeadZone) return ButtonState.Released;
                    else if (m_CurrentValue > m_DeadZone) return ButtonState.Down;
                        break;
                case ReadAxis.Negative:
                    if (m_CurrentValue < -m_DeadZone && m_PreValue < -m_DeadZone) return ButtonState.Held;
                    else if (m_CurrentValue < -m_DeadZone && m_PreValue > -m_DeadZone) return ButtonState.Down;
                    else if (m_CurrentValue > -m_DeadZone && m_PreValue < -m_DeadZone) return ButtonState.Released;
                    else if (m_CurrentValue < -m_DeadZone) return ButtonState.Down;
                    break;
            }
           
            return ButtonState.NotPressed;
        }
    }
}
