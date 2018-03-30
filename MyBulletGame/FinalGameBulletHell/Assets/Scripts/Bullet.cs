using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
    public float speed;
    public int damage = 1;

    private void Start()
    {
		//Maakt dat bullets naar voren gaat en dat je de snelheid kan aan passen
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }


	//Zorgt dat als bullet player of enemy raakt verliest het object dat player of enemy kan zijn "health"
    void OnTriggerEnter(Collider collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health)
        {
            health.TakeDamage(damage);
        }

		// zorgt er voor dat bullets kapot gaan als ze botsen
        if (!collision.GetComponent<KillBox>())
        {
            Destroy(gameObject);
        }
    }
}
