using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace GameInput
{
    public enum Direction
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
        public Direction notation;
        public Vector2 direction;

        public InputDirection(Direction Notation, Vector2 Direction)
        {
            notation = Notation;
            direction = Direction;
        }

    }

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

        public VirtualController GetController(XboxController id)
        {
            int idToCheck = (int)id - 1;
            if (idToCheck < 0 || idToCheck > m_Controllers.Length - 1)
                return null;

            return m_Controllers[idToCheck];

        }

         //5+(raw horizontal axis)+(3*raw vertical axis) 
        public InputDirection GetDirection(XboxController id)
        {
            InputDirection dir = new InputDirection(Direction.Neutral, Vector2.zero);

            int idToCheck = (int)id - 1;
            if (idToCheck < 0 || idToCheck > m_Controllers.Length - 1)
                //return InputDirection.Neutral;
                return dir;


            if (m_Controllers[idToCheck].GetButton(Button.Up).GetButtonState() == ButtonState.Down || m_Controllers[idToCheck].GetButton(Button.Up).GetButtonState() == ButtonState.Held)
            {
                dir.notation += 3;
                dir.direction.y += 1;
            }

            if (m_Controllers[idToCheck].GetButton(Button.Down).GetButtonState() == ButtonState.Down || m_Controllers[idToCheck].GetButton(Button.Down).GetButtonState() == ButtonState.Held)
            {
                dir.notation += -3;
                dir.direction.y += -1;
            }

            if (m_Controllers[idToCheck].GetButton(Button.Left).GetButtonState() == ButtonState.Down || m_Controllers[idToCheck].GetButton(Button.Left).GetButtonState() == ButtonState.Held)
            {
                dir.notation += -1;
                dir.direction.x += -1;
            }

            if (m_Controllers[idToCheck].GetButton(Button.Right).GetButtonState() == ButtonState.Down || m_Controllers[idToCheck].GetButton(Button.Right).GetButtonState() == ButtonState.Held)
            {
                dir.notation += 1;
                dir.direction.x += 1;
            }

            return dir;
        }
    }
}
