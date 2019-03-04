using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RHL.Scripts.Model;
using RHL.Scripts.InputSystem;

//this class is meant to be attached to a lineRenderer prefab
//and have the playerObject and arcOriginObject gameObjects specified
public class RHTeleportHandler : MonoBehaviour {

    public GameObject teleportPointer;

	//maximum number of arc segments that will be calculated
	const int maxSegments = 200;

    RaycastHit hit;

    /// <summary>
    /// This is the maximum distance someone can teleport
    /// </summary>
    [SerializeField]
    private float teleportingRange = 10f;

    [SerializeField]
	public GameObject playerObject;
	//this gameobject is the one that will be teleported

	[SerializeField]
	public GameObject arcOriginObject;
	//this object is the one that will generate the teleportation arc

	[SerializeField]
	public float power = 4.5f;
	//this defines how far out the arc will go

	[SerializeField]
	public float playerHeight;
    //this offsets the teleport destination by a vertical amount

        /// <summary>
        /// Determines which button causes teleportation
        /// </summary>
    public RHButtonMask TeleportOnButton = RHButtonMask.Trigger;

    private bool justTeleported = false;
	void Update() {
        if ( (TeleportOnButton == RHButtonMask.Trigger && RHControllerManager.Instance.PrimaryTriggerPressed) ||
             (TeleportOnButton == RHButtonMask.Touchpad && RHControllerManager.Instance.PrimaryTouchpadPressed) )
        {
            hit = fire();
        }
        if ( ((TeleportOnButton == RHButtonMask.Trigger && RHControllerManager.Instance.PrimaryTriggerReleased) ||
             (TeleportOnButton == RHButtonMask.Touchpad && RHControllerManager.Instance.PrimaryTouchpadReleased))
             && !justTeleported) { //TODO: check the RHL TriggerPulled boolean
			playerObject.transform.position = hit.point + new Vector3(0f, playerHeight, 0f);
			justTeleported = true;
            teleportPointer.GetComponent<Renderer>().enabled = false;
        }
        else if ((TeleportOnButton == RHButtonMask.Trigger && !RHControllerManager.Instance.PrimaryTriggerReleased) ||
             (TeleportOnButton == RHButtonMask.Touchpad && !RHControllerManager.Instance.PrimaryTouchpadReleased) ) { //another one to fix
			justTeleported = false;
		}
	}

	//this function throws the gun in an arc, drawing the arc in the air,
	//and identifying the point at which it lands with a beacon
	public RaycastHit fire() {
        RaycastHit fireHit;
        if(Physics.Raycast(arcOriginObject.transform.position, arcOriginObject.transform.forward, out fireHit, teleportingRange))
        {
            teleportPointer.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            fireHit.point = new Vector3(playerObject.transform.position.x, 0f, playerObject.transform.position.z); // If raycast did not hit an object, simply keep player where they are
        }
        return fireHit;
    }
}
