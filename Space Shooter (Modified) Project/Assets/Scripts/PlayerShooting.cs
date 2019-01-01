using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour 
{
	public Transform shotSpawn;
	public GameObject bolt;
	public float boltRate = 0.2f;

	AudioSource audioSource;

	float timer;

	void Awake()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (Input.GetKey (KeyCode.Space) && timer >= boltRate) 
		{	
			Instantiate (bolt, shotSpawn.position, shotSpawn.rotation);
			timer = 0f;	
			audioSource.Play ();
		}
	}

}
