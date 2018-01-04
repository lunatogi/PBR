using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Animator anim;
    Rigidbody2D rigidbodyPlayer;
    SpriteRenderer s_Renderer;

    public GameObject bullet;       //Ateş edilecek mermi ve çıkış noktası
    public Transform attackLoc;

    public float maxSpeed = 5f;     //Koşma için olan maxSpeed

    bool is_walking;

    int direction = 0;
    int bulletDirection;

	void Start () {
        anim = transform.gameObject.GetComponent<Animator>();
        rigidbodyPlayer = transform.gameObject.GetComponent<Rigidbody2D>();
        s_Renderer = transform.gameObject.GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate () {

        if (direction != 0)
            bulletDirection = direction;

        if (is_walking)
        {
            
        }
        else
        {
            
            direction = 0;
        }

        try
        {
            rigidbodyPlayer.velocity = new Vector2(direction * maxSpeed, rigidbodyPlayer.velocity.y);       //Tuşlara basılınca direction değişir ve ona göre karakter hareket eder
        }
        catch
        {

        }
    }

    public void GoRight()           //Sağa giderken olması gerenler
    {
        anim.Play("girlwalkingAnim");
        direction = 1;
        FlipX(direction);
        is_walking = true;
    }

    public void GoLeft()            //Sola giderken olması gerekenler
    {
        anim.Play("girlwalkingAnim");
        direction = -1;
        FlipX(direction);
        is_walking = true;
    }

    public void PointerUp()
    {
        is_walking = false;
        anim.Play("girlidleAnim");
    }






    public void Attack()
    {
        anim.Play("girlattackAnim");
        Invoke("InvokeBullet", 0.2f);       //Delayle mermi atımını sağlar
    }

    public void InvokeBullet()
    {
        GameObject bult = Instantiate(bullet, attackLoc.position, attackLoc.rotation);    //Mermi oluşturur
        bult.SendMessage("DirectionSet", bulletDirection);
    }




    public void FlipX(int direction)
    {
        if (direction == 1)
        {
            if (transform.localScale.x < 0)
            {
                Vector2 new_Scale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                transform.localScale = new_Scale;
            }
        }else if(direction == -1)
        {
            if(transform.localScale.x > 0)
            {
                Vector2 new_Scale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                transform.localScale = new_Scale;
            }
        }
    }
}
