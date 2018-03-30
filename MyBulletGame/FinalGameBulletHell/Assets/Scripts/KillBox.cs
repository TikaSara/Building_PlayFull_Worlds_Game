using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class KillBox : MonoBehaviour {

	// Deze code zorgt er voor dat het controlleert of de collider een trigger is
	private void Awake()
	{
        if (!GetComponent<BoxCollider>().isTrigger) Debug.LogError(transform.parent.name + " Box Collider should be a trigger.");
	}

	// Als iets de randen raakt van de kill box dan despawnen het 
	private void OnTriggerExit(Collider collision)
	{
        Destroy(collision.transform.root.gameObject);
	}
}
