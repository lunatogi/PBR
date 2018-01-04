using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody2D rigidbodyBullet;

    public float speed = 20f;
    int direction = 1;

    public float lifetime = 2f;

    public int damage = 5;

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
        if (collision.gameObject.tag == "Enemy")
        {
            print("damaged");
            collision.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(transform.gameObject);
        }
    }

    public void DirectionSet(int direc)
    {
        direction = direc;
        print("sex");
    }


}
