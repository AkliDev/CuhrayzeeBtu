using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace GameInput
{
    public class InputManager
    {
        private VirtualController[] m_Controllers;

        private void Init()
        {
            m_Controllers = new VirtualController[4]
            {
                new VirtualController(XboxController.First),
                new VirtualController(XboxController.Second),
                new VirtualController(XboxController.Third),
                new VirtualController(XboxController.Fourth)
            };
        }

        public InputManager()
        {
            MonoBehaviour.print("InputManager Created");
            Init();
        }

        public ButtonState GetButtonState(XboxController id, VButton button)
        {
            int idToCheck = (int)id - 1;
            if (idToCheck < 0 || idToCheck > m_Controllers.Length - 1)
                return ButtonState.NotPressed;

            return m_Controllers[idToCheck].GetButtonState(button);
        }

        public IsButtonPressed CheckIsButtonPressed(XboxController id, VButton button)
        {
            int idToCheck = (int)id - 1;
            if (idToCheck < 0 || idToCheck > m_Controllers.Length - 1)
                return IsButtonPressed.NotPressed;

            return m_Controllers[idToCheck].CheckIsButtonPressed(button);
        }

        public float GetButtonHeldTime(XboxController id, VButton button)
        {
            int idToCheck = (int)id - 1;
            if (idToCheck < 0 || idToCheck > m_Controllers.Length - 1)
                return 0;

            return m_Controllers[idToCheck].GetButtonHeldTime(button);
        }

        public InputDirection GetDirection(XboxController id)
        {
            int idToCheck = (int)id - 1;
            if (idToCheck < 0 || idToCheck > m_Controllers.Length - 1)
                return null;

            return m_Controllers[idToCheck].GetDirection();
        }

        public void Update()
        {
            for (int i = 0; i < m_Controllers.Length; i++)
            {
                m_Controllers[i].Update();
            }
        }
    }
}
