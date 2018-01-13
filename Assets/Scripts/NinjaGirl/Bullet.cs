using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {
    Rigidbody2D rigidbodyBullet;

    public float speed = 20f;

    [SyncVar(hook = "DirectionSet")]
    int direction = 1;

    public float lifetime = 2f;

    public int damage = 10;

	void Start () {
        rigidbodyBullet = transform.gameObject.GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        print(direction);
        rigidbodyBullet.velocity = new Vector2(direction * speed, rigidbodyBullet.velocity.y);

        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
            Destroy(transform.gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("damaged");
            collision.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
            var hit = collision.gameObject;
            var health = hit.GetComponent<Health>();
            health.TakeDamage(damage);
            Destroy(transform.gameObject);
        }
    }

    public void DirectionSet(int direc)
    {
        direction = direc;
        print("sex");
    }


}
