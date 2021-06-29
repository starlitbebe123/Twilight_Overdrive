using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : MonoBehaviour
{
    public GameObject Player;
    public Transform playerPos;

    public float speed;
    public bool facingLeft;
    public bool moveLeft;
    public bool isAttacking;
    public bool Idel;
    public Animator anim;
    public float dist;
    public float animLength;

    public AudioClip ElectricAud;
    AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerPos = Player.GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        dist = playerPos.transform.position.x - gameObject.transform.position.x;
        if (dist < 0 && facingLeft)
            Flip();
        if (dist > 0 && !facingLeft)
            Flip();
        if (dist <= -5 && dist >= -30) 
            { 
            moveLeft = true;
            Idel = false;
            }
        if (dist >= 5 && dist <= 30)
            {
            moveLeft = false;
            Idel = false; 
            }
        if (moveLeft && isAttacking == false && Idel == false)
        {
            anim.SetBool("Walk", true);
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        if (!moveLeft && isAttacking == false && Idel == false)
        {
            anim.SetBool("Walk", true);
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }

        if (dist > 30 || dist < -30)
            anim.SetBool("Walk", false);
            Idel = true; 

        if (dist <= 5 && dist >= -5 && isAttacking == false)
        {
            Attack();
        }
        
    }
    void Attack()
    {
        isAttacking = true;
        anim.SetBool("Attack", true);
        audioSource.PlayOneShot(ElectricAud, 1F);
        StartCoroutine(Attacking());
    }
    
    

    void Flip()
    {
    facingLeft = !facingLeft;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
    }
   
    IEnumerator Attacking()
    { 
    yield return new WaitForSeconds(1.5f);
    isAttacking = false;
    anim.SetBool("Attack", false);
    }
    
}



