using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    GameObject ChickenSprite;
    public Vector3 pos;
    public GameObject PointA;
    public Vector3 PosA;
    public GameObject PointB;
    public Vector3 PosB;
    public bool isMoveB;
    Animator anim;
    public float speed;
    public float distA;
    public float distB;
    public bool facingRight;

    public GameObject bulletPoint;
    public GameObject bulletPoint2;
    public GameObject bulletSpawn;
    public GameObject bulletSpawn2;
    public GameObject bulletSpawn3;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        PosA = PointA.transform.position;
        PosB = PointB.transform.position;
        pos = this.transform.position;
        pos = Vector3.Lerp(pos, new Vector2(pos.x,5f), 100*Time.deltaTime);

    }

    void Update()
    {
        distA = Vector3.Distance(pos, PosA);
        distB = Vector3.Distance(pos, PosB);
        if (distA  < 1  && facingRight) 
        {
            anim.SetBool("Move", false);
            StartCoroutine(CountB());
            Flip(); 
        }
        if (distB < 1  && !facingRight)
        {
            anim.SetBool("Move", false);
            StartCoroutine(CountA());
            Flip();
        }
        if (isMoveB == true) 
        {
            MovingB();
        }
        else if (isMoveB == false)
        {
            MovingA();
        }

      
    }
 
    void MovingB() 
    {
        pos = this.transform.position;
        pos = Vector3.Lerp(pos, PosB, speed * Time.deltaTime);
        //anim.SetBool("movingLeft", true);
        this.transform.position = pos;
    }
    void MovingA()
    {
        pos = this.transform.position;
        pos = Vector3.Lerp(pos, PosA, speed * Time.deltaTime);
        //anim.SetBool("movingLeft", true);
        this.transform.position = pos;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale; 
    }

    void Shoot() 
    {
        GameObject temp = Instantiate(bulletSpawn,bulletPoint.transform.position, Quaternion.identity);
        Destroy(temp, 5f);
    }
    void ShootMove()
    {

        if(isMoveB == true) 
        {
            GameObject temp2 = Instantiate(bulletSpawn2, bulletPoint2.transform.position, Quaternion.identity);
            Destroy(temp2, 5f);
        }
       else if (isMoveB == false)
        {
            GameObject temp3 = Instantiate(bulletSpawn3, bulletPoint2.transform.position, Quaternion.identity);
            Destroy(temp3, 5f);
        }
       
    }

    IEnumerator CountB()
    {
        {
            
            yield return new WaitForSeconds(4f);
            isMoveB = true;
            anim.SetBool("Move", true);
            
        }
    }
    
    IEnumerator CountA()
    {
        {
            yield return new WaitForSeconds(4f);
            isMoveB = false;
            anim.SetBool("Move", true);
           
        }
    }
}
