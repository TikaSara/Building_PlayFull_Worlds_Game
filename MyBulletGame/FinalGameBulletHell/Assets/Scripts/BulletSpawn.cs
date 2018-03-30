using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {

    public GameObject Bullet;
    public Transform SpawnPoint;
	public float fireRate;

	private float nextFire = 0;

	// zorgt er voor dat de bullets van uit de spawnpoint komen, 
	// ook regelt het de tijd die het duurt voordat er een nieuwe bullet spawned
	void Update()
    {
		if (Time.time > nextFire) 
        {
			nextFire = Time.time + fireRate;
			Instantiate (Bullet, SpawnPoint.position, SpawnPoint.rotation);
		}
	}
}
