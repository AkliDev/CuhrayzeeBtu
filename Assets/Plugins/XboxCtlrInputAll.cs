using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XboxCtrlrInput
{
    public static class XCIA
    {
       

        public static List<XboxButton> GetButtonAll(XboxController controller)
        {
            List<XboxButton> buttonList = new List<XboxButton>();

            if (XCI.GetButton(XboxButton.A, controller))
            {
                buttonList.Add(XboxButton.A);
            }

            if (XCI.GetButton(XboxButton.B, controller))
            {
                buttonList.Add(XboxButton.B);
            }

            if (XCI.GetButton(XboxButton.X, controller))
            {
                buttonList.Add(XboxButton.X);
            }

            if (XCI.GetButton(XboxButton.Y, controller))
            {
                buttonList.Add(XboxButton.Y);
            }

            if (XCI.GetButton(XboxButton.Start, controller))
            {
                buttonList.Add(XboxButton.Start);
            }

            if (XCI.GetButton(XboxButton.Back, controller))
            {
                buttonList.Add(XboxButton.Back);
            }

            if (XCI.GetButton(XboxButton.LeftStick, controller))
            {
                buttonList.Add(XboxButton.LeftStick);
            }

            if (XCI.GetButton(XboxButton.RightStick, controller))
            {
                buttonList.Add(XboxButton.RightStick);
            }

            if (XCI.GetButton(XboxButton.LeftBumper, controller))
            {
                buttonList.Add(XboxButton.LeftBumper);
            }

            if (XCI.GetButton(XboxButton.RightBumper, controller))
            {
                buttonList.Add(XboxButton.RightBumper);
            }

            if (XCI.GetButton(XboxButton.DPadUp, controller))
            {
                buttonList.Add(XboxButton.DPadUp);
            }

            if (XCI.GetButton(XboxButton.DPadDown, controller))
            {
                buttonList.Add(XboxButton.DPadDown);
            }

            if (XCI.GetButton(XboxButton.DPadLeft, controller))
            {
                buttonList.Add(XboxButton.DPadLeft);
            }

            if (XCI.GetButton(XboxButton.DPadRight, controller))
            {
                buttonList.Add(XboxButton.DPadRight);
            }

            return buttonList;
        }

        public static List<XboxButton> GetButtonDownAll(XboxController controller)
        {
            List<XboxButton> buttonList = new List<XboxButton>();

            if (XCI.GetButtonDown(XboxButton.A, controller))
            {
                buttonList.Add(XboxButton.A);
            }

            if (XCI.GetButtonDown(XboxButton.B, controller))
            {
                buttonList.Add(XboxButton.B);
            }

            if (XCI.GetButtonDown(XboxButton.X, controller))
            {
                buttonList.Add(XboxButton.X);
            }

            if (XCI.GetButtonDown(XboxButton.Y, controller))
            {
                buttonList.Add(XboxButton.Y);
            }

            if (XCI.GetButtonDown(XboxButton.Start, controller))
            {
                buttonList.Add(XboxButton.Start);
            }

            if (XCI.GetButtonDown(XboxButton.Back, controller))
            {
                buttonList.Add(XboxButton.Back);
            }

            if (XCI.GetButtonDown(XboxButton.LeftStick, controller))
            {
                buttonList.Add(XboxButton.LeftStick);
            }

            if (XCI.GetButtonDown(XboxButton.RightStick, controller))
            {
                buttonList.Add(XboxButton.RightStick);
            }

            if (XCI.GetButtonDown(XboxButton.LeftBumper, controller))
            {
                buttonList.Add(XboxButton.LeftBumper);
            }

            if (XCI.GetButtonDown(XboxButton.RightBumper, controller))
            {
                buttonList.Add(XboxButton.RightBumper);
            }

            if (XCI.GetButtonDown(XboxButton.DPadUp, controller))
            {
                buttonList.Add(XboxButton.DPadUp);
            }

            if (XCI.GetButtonDown(XboxButton.DPadDown, controller))
            {
                buttonList.Add(XboxButton.DPadDown);
            }

            if (XCI.GetButtonDown(XboxButton.DPadLeft, controller))
            {
                buttonList.Add(XboxButton.DPadLeft);
            }

            if (XCI.GetButtonDown(XboxButton.DPadRight, controller))
            {
                buttonList.Add(XboxButton.DPadRight);
            }

            return buttonList;
        }

        public static List<XboxButton> GetButtonUpAll(XboxController controller)
        {
            List<XboxButton> buttonList = new List<XboxButton>();

            if (XCI.GetButtonUp(XboxButton.A, controller))
            {
                buttonList.Add(XboxButton.A);
            }

            if (XCI.GetButtonUp(XboxButton.B, controller))
            {
                buttonList.Add(XboxButton.B);
            }

            if (XCI.GetButtonUp(XboxButton.X, controller))
            {
                buttonList.Add(XboxButton.X);
            }

            if (XCI.GetButtonUp(XboxButton.Y, controller))
            {
                buttonList.Add(XboxButton.Y);
            }

            if (XCI.GetButtonUp(XboxButton.Start, controller))
            {
                buttonList.Add(XboxButton.Start);
            }

            if (XCI.GetButtonUp(XboxButton.Back, controller))
            {
                buttonList.Add(XboxButton.Back);
            }

            if (XCI.GetButtonUp(XboxButton.LeftStick, controller))
            {
                buttonList.Add(XboxButton.LeftStick);
            }

            if (XCI.GetButtonUp(XboxButton.RightStick, controller))
            {
                buttonList.Add(XboxButton.RightStick);
            }

            if (XCI.GetButtonUp(XboxButton.LeftBumper, controller))
            {
                buttonList.Add(XboxButton.LeftBumper);
            }

            if (XCI.GetButtonUp(XboxButton.RightBumper, controller))
            {
                buttonList.Add(XboxButton.RightBumper);
            }

            if (XCI.GetButtonUp(XboxButton.DPadUp, controller))
            {
                buttonList.Add(XboxButton.DPadUp);
            }

            if (XCI.GetButtonUp(XboxButton.DPadDown, controller))
            {
                buttonList.Add(XboxButton.DPadDown);
            }

            if (XCI.GetButtonUp(XboxButton.DPadLeft, controller))
            {
                buttonList.Add(XboxButton.DPadLeft);
            }

            if (XCI.GetButtonUp(XboxButton.DPadRight, controller))
            {
                buttonList.Add(XboxButton.DPadRight);
            }

            return buttonList;
        }

        public static List<XboxAxis> GetAxisAll(XboxController controller)
        {
            List<XboxAxis> axisList = new List<XboxAxis>();

            if (XCI.GetAxisRaw(XboxAxis.LeftStickX, controller) != 0)
            {
                axisList.Add(XboxAxis.LeftStickX);
            }

            if (XCI.GetAxisRaw(XboxAxis.LeftStickY, controller) != 0)
            {
                axisList.Add(XboxAxis.LeftStickY);
            }

            if (XCI.GetAxisRaw(XboxAxis.RightStickX, controller) != 0)
            {
                axisList.Add(XboxAxis.RightStickX);
            }

            if (XCI.GetAxisRaw(XboxAxis.RightStickY, controller) != 0)
            {
                axisList.Add(XboxAxis.RightStickY);
            }

            if (XCI.GetAxisRaw(XboxAxis.LeftTrigger, controller) != 0)
            {
                axisList.Add(XboxAxis.LeftTrigger);
            }

            if (XCI.GetAxisRaw(XboxAxis.RightTrigger, controller) != 0)
            {
                axisList.Add(XboxAxis.RightTrigger);
            }

            return axisList;
        }
    }
}
