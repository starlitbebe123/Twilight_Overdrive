using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBullet : MonoBehaviour
{
    Rigidbody2D rig;
    public float xSpeed;
    public float ySpeed;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HurtBox")
        {
            Destroy(gameObject);
        }
    }
}
