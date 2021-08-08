using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    GameObject Capsule;
    GameObject GoalCollider;
    
    public GameObject Explosion;

    private void Start()
    {
        Capsule = GameObject.Find("Capsule");
        GoalCollider = GameObject.Find("GoalCollider");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitBox")
        {
            Capsule.SetActive(false);
            GameObject temp = Instantiate(Explosion, transform.position, Quaternion.identity);
            GoalCollider.SetActive(true);
            Destroy(temp, 2f);
            Destroy(gameObject); 
        }

       
    }
}
