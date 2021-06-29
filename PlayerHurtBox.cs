ㄖusing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{


 
    public Animator anim;
    public bool hurtFromRight;
    public Rigidbody2D rgbd;

     
    public float PlayerHp;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DamageBox")
        {
            anim.SetBool("Hurt", true);
            if (transform.position.x < other.transform.position.x)
                hurtFromRight = true;
            else
                hurtFromRight = false;
            Bounce();

            HP = HP - other.GetComponent<DamageFunction>().Dmg;
            
        }

    }



    void Bounce()
    {
        if (hurtFromRight)
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000, 0));
            rgbd.velocity = new Vector2(-2, 0);
        else if (!hurtFromRight)
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));
            rgbd.velocity = new Vector2(2, 0);

    }
}


