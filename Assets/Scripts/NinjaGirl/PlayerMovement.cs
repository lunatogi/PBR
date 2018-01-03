using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rigidbody;

    public GameObject bullet;       //Ateş edilecek mermi ve çıkış noktası
    public Transform attackLoc;

    public float maxSpeed = 5f;     //Koşma için olan maxSpeed

    bool b_goright = false;         //Sağa sola gitmeyi kontrol eden bollar
    bool b_goleft = false ;

	void Start () {
        rigidbody = transform.gameObject.GetComponent<Rigidbody2D>();

    }
	
	void FixedUpdate () {
		if(b_goright)
            rigidbody.velocity = new Vector2(1 * maxSpeed, rigidbody.velocity.y);       //Sağa gidiş

        if(b_goleft)
            rigidbody.velocity = new Vector2(-1 * maxSpeed, rigidbody.velocity.y);      //Sola gidiş
    }

    public void GoRight()           //Sağa giderken olması gerenler
    {
        b_goright = true;
    }

    public void GoLeft()            //Sola giderken olması gerekenler
    {
        b_goleft = true;
    }

    public void PointerUp()
    {
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y);         //Hiçbir tuşa basmıyorken durmasını sağlar
        b_goleft = false;
        b_goright = false;
    }

    public void Attack()
    {
        Invoke("InvokeBullet", 0.0f);       //Delayle mermi atımını sağlar
    }

    public void InvokeBullet()
    {
        Instantiate(bullet, attackLoc.position, attackLoc.rotation);    //Mermi oluşturur
    }
}
