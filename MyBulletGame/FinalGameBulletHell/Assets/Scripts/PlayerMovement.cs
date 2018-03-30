using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    private Rigidbody rigidbody;

	private void Start()
	{
        rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
    {
		// vraagt imput van de speler 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		// zet input om in beweging 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

		// past de beweging toe aan de player object
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );
    }
}
