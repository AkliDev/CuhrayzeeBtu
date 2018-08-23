using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using GameInput;

public class Player : Actor {

    public XboxController m_ControllerId;
    public float testSpeedHorizontal;
    public float testSpeedVertical;

    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        // ghetto for now, Physics will eventually be controlled by state's instructions
        switch (GameManager.instance.InputManager.GetDirection(m_ControllerId).notation)
        {
            case DirectionNotaton.Up:
                Physics.VerticalMovement.SetVelocity(testSpeedVertical);
                break;
            case DirectionNotaton.UpLeft:
                Physics.VerticalMovement.SetVelocity(testSpeedVertical);
                Physics.HorizontalMovement.SetVelocity(-testSpeedHorizontal);
                break;
            case DirectionNotaton.UpRight:
                Physics.VerticalMovement.SetVelocity(testSpeedVertical);
                Physics.HorizontalMovement.SetVelocity(testSpeedHorizontal);
                break;

            case DirectionNotaton.Left:
                Physics.HorizontalMovement.SetVelocity(-testSpeedHorizontal);
                break;
            case DirectionNotaton.Neutral:
                Physics.VerticalMovement.SetVelocity(0f);
                Physics.HorizontalMovement.SetVelocity(0f);
                break;
            case DirectionNotaton.Right:
                Physics.HorizontalMovement.SetVelocity(testSpeedHorizontal);
                break;

            case DirectionNotaton.Down:
                Physics.VerticalMovement.SetVelocity(-testSpeedVertical);
                break;
            case DirectionNotaton.DownLeft:
                Physics.VerticalMovement.SetVelocity(-testSpeedVertical);
                Physics.HorizontalMovement.SetVelocity(-testSpeedHorizontal);
                break;
            case DirectionNotaton.DownRight:
                Physics.VerticalMovement.SetVelocity(-testSpeedVertical);
                Physics.HorizontalMovement.SetVelocity(testSpeedHorizontal);
                break;
        }

        Physics.UpdatePhysics();
    }
}
