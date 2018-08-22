using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace GameInput
{
    public class InputManager
    {
        private VirtualController[] m_Controllers;
        public InputBuffer[] m_Inputbuffers;

        private void Init()
        {
            m_Controllers = new VirtualController[(int)XboxController.Fourth]
            {
                new VirtualController(XboxController.First),
                new VirtualController(XboxController.Second),
                new VirtualController(XboxController.Third),
                new VirtualController(XboxController.Fourth)
            };

            m_Inputbuffers = new InputBuffer[(int)XboxController.Fourth]
            {
                    new InputBuffer(this, XboxController.First),
                    new InputBuffer(this, XboxController.Second),
                    new InputBuffer(this, XboxController.Third),
                    new InputBuffer(this, XboxController.Fourth)
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

            return m_Controllers[idToCheck].GetIsButtonPressed(button);
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
            //if (idToCheck < 0 || idToCheck > m_Controllers.Length - 1)
            //    return null;

            return m_Controllers[idToCheck].InputDirection;
        }

        public InputDirection[] GetInputBuffer(XboxController id)
        {
            int idToCheck = (int)id - 1;
            if (idToCheck < 0 || idToCheck > m_Controllers.Length - 1)
                return null;

            return m_Inputbuffers[idToCheck].DirectionalInputBuffer;
        }

        public void Update()
        {
            for (int i = 0; i < 1; i++)
            {
                m_Controllers[i].Update();
                m_Inputbuffers[i].Update();
            }
        }
    }
}
