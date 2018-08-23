using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour {

    public ActorPhysics Physics { get; private set; }
    public ActorOffense Offense { get; private set; }
    public ActorDefense Defense { get; private set; }

    // Use this for initialization
    public void Start () {
        Physics = gameObject.GetComponentInChildren<ActorPhysics>();
        Offense = gameObject.GetComponentInChildren<ActorOffense>();
        Defense = gameObject.GetComponentInChildren<ActorDefense>();

    }
	
	// Update is called once per frame
	/*public void Update () {
        Physics.UpdatePhysics();
	}  */
}
