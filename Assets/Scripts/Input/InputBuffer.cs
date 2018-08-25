using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace GameInput
{
    public class InputBuffer
    {
        InputManager m_Inputmanager;

        XboxController m_ControllerId;
        private InputDirection[] m_DirectionalInputBuffer;
        private InputDirection m_CurrentDirectionInput;
        private DirectionNotaton m_PreDirectionInput;

        public InputDirection[] DirectionalInputBuffer { get { return m_DirectionalInputBuffer; } }

        private void Init()
        {
            m_DirectionalInputBuffer = new InputDirection[10];

            for (int i = 0; i < m_DirectionalInputBuffer.Length; i++)
            {
                m_DirectionalInputBuffer[i] = new InputDirection();
            }
        }

        private void AddToBuffer()
        {
            if (m_CurrentDirectionInput.notation == m_PreDirectionInput || m_CurrentDirectionInput.notation == DirectionNotaton.Neutral)
                return;

            for (int i = 0; i < m_DirectionalInputBuffer.Length - 1; i++)
            {
                m_DirectionalInputBuffer[i] = m_DirectionalInputBuffer[i + 1];
            }

            m_DirectionalInputBuffer[m_DirectionalInputBuffer.Length - 1] = m_CurrentDirectionInput;
        }

        private void UpdateDirectionHeldTimer()
        {
            if (m_CurrentDirectionInput.notation == DirectionNotaton.Neutral)
                return;

            m_DirectionalInputBuffer[m_DirectionalInputBuffer.Length - 1].heldTime += Time.deltaTime;
        }

        public InputBuffer(InputManager inputManager, XboxController controllerId)
        {
            m_Inputmanager = inputManager;
            m_ControllerId = controllerId;
            Init();
        }

        public void Update()
        {
            m_CurrentDirectionInput = m_Inputmanager.GetDirection(m_ControllerId);
            AddToBuffer();
            UpdateDirectionHeldTimer();

            m_PreDirectionInput = m_CurrentDirectionInput.notation;
        }
    }
}
