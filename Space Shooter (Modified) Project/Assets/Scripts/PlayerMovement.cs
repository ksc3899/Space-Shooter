using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerLimits
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 10f;
	public float tilt = 5f;
	public PlayerLimits playerLimits;

	Rigidbody playerRigidbody;

	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Vector3 movement = new Vector3 (h, 0f, v);
		movement = movement.normalized * speed;
		playerRigidbody.velocity = movement;

		Quaternion tiltRotation = Quaternion.Euler (0f, 0f, playerRigidbody.velocity.x * -tilt);
		playerRigidbody.rotation = tiltRotation;

		playerRigidbody.transform.position = new Vector3
			(
				Mathf.Clamp (playerRigidbody.position.x, playerLimits.xMin, playerLimits.xMax),
				0f,
				Mathf.Clamp (playerRigidbody.position.z, playerLimits.zMin, playerLimits.zMax)
			);
	}
}
