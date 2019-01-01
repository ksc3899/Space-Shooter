using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour 
{
	private Rigidbody rb;
	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public GameObject shotSpawn;
	public float fireRate;
	private float nextFire=0.0f;

	private AudioSource audioSource;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}
	

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
			audioSource.Play ();
		}
	}



	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.transform.position = new Vector3 
		(
			Mathf.Clamp (rb.transform.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.transform.position.z, boundary.zMin, boundary.zMax)
		);

		rb.transform.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

	}
}
