using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float EnemyHp;
    GameObject Player;
    float PlayerATK;
    Color originalColor;
    SpriteRenderer rend;
    public GameObject Explosion;
    Vector3 pos;
    public Vector3 exploPos;
    public AudioClip HitAud;
    AudioSource audioSource;


    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rend = gameObject.GetComponent<SpriteRenderer>();
        originalColor = rend.color;
    }

    // Update is called once per frame
    private void Update()
    {
        pos = gameObject.transform.position; 
        PlayerATK = Player.GetComponent<PlayerControl>().damageAttack;
        if (EnemyHp <= 0)
        {
            GameObject temp = Instantiate(Explosion, pos + exploPos, Quaternion.identity);
            Destroy(temp, 2f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitBox")
        {
            EnemyHp = EnemyHp - PlayerATK;
            FlashRed();
            if(Player.GetComponent<PlayerStat>().playerHp < Player.GetComponent<PlayerStat>().playerMaxHp)
            Player.GetComponent<PlayerStat>().playerHp += 2;
            audioSource.PlayOneShot(HitAud, 1F);
        }
    }

    private void FlashRed()
    {
        rend.color = Color.red;
        Invoke("ResetColor", 0.1f);
    }
    private void ResetColor()
    {
        rend.color = originalColor;
    }
}
