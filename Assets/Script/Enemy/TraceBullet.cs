using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceBullet : MonoBehaviour
{
    GameObject Player;
   
    public float bulletSpeed = 7;
    Rigidbody2D rb;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (Player.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 720 * Time.deltaTime));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "HurtBox")
        {
            Destroy(gameObject);
        }
    }
}
