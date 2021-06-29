using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float maxSpeed = 2f;

    public Animator anim;
    public bool facingRight = true;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;
    public float jumpForce;
    bool moving = false;

    bool Attacking ;
    bool Hurting;
    public bool Dead;

    public Rigidbody2D rigidbody;
    public RigidbodyConstraints constraints;


    private SpriteRenderer mySpriteRenderer;

    public bool hurtFromRight;

    public GameObject projectile;
    public GameObject projectile2;

    public float MPCost;
    public float MP2Cost;
    public GameObject player;

    // Use this for initialization


    void Start()
    {
        
         
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
       
    }
 
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        if (Attacking == true && grounded == false && Hurting == false && Dead == false)
        {
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move));

            if (move > 0 && !facingRight && Attacking == false)
                Flip();
            else if (move < 0 && facingRight && Attacking == false)
                Flip();
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Attacking == false && Hurting == false && Dead == false)
        {
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move));

            if (move > 0 && !facingRight && Attacking == false)
                Flip();
            else if (move < 0 && facingRight && Attacking == false)
                Flip();
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetButtonDown("Jump") && Dead == false)
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

        }


       // if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        //{
          //  anim.SetBool("Run", true);
        //}
        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        //{
          //  anim.SetBool("Run", false);
        //}


        //if (Input.GetKey(KeyCode.D))
        //{
          //  gameObject.transform.position += new Vector3(0.03f, 0, 0);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0.01f, 0);
            //mySpriteRenderer.flipX = false;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
          //  gameObject.transform.position += new Vector3(-0.03f, 0, 0);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-0.01f, 0);
            //mySpriteRenderer.flipX = true;
       // }

        if (Attacking == false && Input.GetButtonDown("Fire1") && Dead == false)
        {
            anim.SetBool("Attack", true);
            Attacking = true;
            //rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX; 
        }

        if (Attacking == false && Input.GetButtonDown("Fire2") && Dead == false)
        {
            anim.SetBool("Magic", true);
            Attacking = true;
            
            //rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX; 
        }

        if (GetComponent<Rigidbody2D>().velocity.y < 0 && Dead == false)
        {
            anim.SetBool("Fall", true);
        }

        if (grounded && Dead == false)
        {
            anim.SetBool("Fall", false);
        }

        if (GetComponent<PlayerStat>().HP <= 0)
        {
            Dead = true;
        }

        if (Dead == true)
        {
            anim.SetBool("Death", true);
            player.GetComponent<PlayerSwitch>().enabled = false;
        }


        //knockbackCount -= Time.deltaTime;
        MPCost = projectile.GetComponent<LightCannonFunction>().MpCost;
        MP2Cost = projectile2.GetComponent<LightCannon2Function>().MpCost;

}
     

    public void AnimationEnd()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Hurt", false);
        anim.SetBool("Magic", false);
        Attacking = false;
        Hurting = false;
    }
    public void usingMagic()
    {
        if (GetComponent<PlayerStat>().MP > MPCost && facingRight)
        {
            Instantiate(projectile, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), transform.rotation);
            GetComponent<PlayerStat>().MP = GetComponent<PlayerStat>().MP - MPCost;
        }
        else if (GetComponent<PlayerStat>().MP > MP2Cost && !facingRight)
        {
            Instantiate(projectile2, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z), transform.rotation);
            GetComponent<PlayerStat>().MP = GetComponent<PlayerStat>().MP - MP2Cost;
        }
        
        

    }

    void Flip()
    {
       
        
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DamageBox")
        {
            Hurting = true;
         //   anim.SetBool("Hurt", true);
         //   if (transform.position.x < other.transform.position.x)
         //        hurtFromRight = true;
          //  else
          //       hurtFromRight = false;
           // Bounce();
        }

         
    }

    //void Bounce()
   // {
     //   if (hurtFromRight)
             
          //  GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
      //  else if (!hurtFromRight)
             
         //   GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
   // 


}