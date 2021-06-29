using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public AudioSource BGMSource;
    public AudioSource GoalSource;

    public AudioClip ItemSound;
    public AudioClip GoalMusic;
    GameObject Capsule;
    GameObject Crystal;
    GameObject WinText;
    public GameObject Explosion;

    private void Start()
    {
        Capsule = GameObject.Find("Capsule");
        Crystal = GameObject.Find("Crystal");
        WinText = GameObject.Find("WinText");
        WinText.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitBox")
        {
            Capsule.SetActive(false);
            GameObject temp = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(temp, 2f);
        }

        if(other.tag == "Player") 
        {
            
            Crystal.SetActive(false);
            WinText.SetActive(true);
            BGMSource.Stop();
            GetComponent<BoxCollider2D>().enabled = false;
            GoalSource.PlayOneShot(ItemSound, 0.5F);
            GoalSource.PlayOneShot(GoalMusic, 1F);
        }
    }
}
