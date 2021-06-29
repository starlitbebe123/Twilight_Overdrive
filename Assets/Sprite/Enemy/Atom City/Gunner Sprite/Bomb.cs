using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject Explosion;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Ground")
        {
            GameObject temp = Instantiate(Explosion,transform.position, Quaternion.identity);
            Destroy(temp, 2f);
            Destroy(gameObject);
        }
    }

}
