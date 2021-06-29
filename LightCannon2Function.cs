using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCannon2Function : MonoBehaviour
{

  
    public GameObject explo;
    
    public float MpCost;
    public float Speed;

    
    void Update()
    {
       
         
        gameObject.transform.position += new Vector3(-Speed, 0, 0);
         
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Instantiate(explo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "DamageBox")
        {
            Instantiate(explo, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }
}