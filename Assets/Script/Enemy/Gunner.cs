using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    GameObject Player;
    public GameObject bullet;
    public Vector3 playerPos;
    public Vector3 posBullet;
    float PlayerATK;
    public float EnemyHp = 9;
    public GameObject Explosion;
    public float dist;
    public float attackRadius;
    Animator anim;
    Color originalColor;
    public SpriteRenderer rend;
    public AudioClip ChargeAud;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>(); 
        anim = GetComponent<Animator>(); 
        Player = GameObject.FindGameObjectWithTag("Player");
        originalColor = rend.color;

        PlayerATK = Player.GetComponent<PlayerControl>().damageAttack;
        if (EnemyHp <= 0)
        {
            GameObject temp = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(temp, 2f);
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float x1 = playerPos.x;
        float x2 = gameObject.transform.position.x;
        dist = Mathf.Floor(Mathf.Abs(x1 - x2));

        //�p�G ���a��ĤH �� �Z�� �p�󵥩� �����d�� �N����
        if (dist <= attackRadius)
        {
            
            anim.SetBool("Attack", true);
            
        }

        if (dist > attackRadius)
        {
            anim.SetBool("Attack", false); 
        }
        LookAtPlayer();
        PlayerATK = Player.GetComponent<PlayerControl>().damageAttack;
        if (EnemyHp <= 0)
        {
            GameObject temp = Instantiate(Explosion,new Vector2(transform.position.x - 0.6f, transform.position.y - 0.4f), Quaternion.identity);
            Destroy(temp, 2f);
            Destroy(gameObject);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, attackRadius);
    }
    void Charge() 
    {
        audioSource.PlayOneShot(ChargeAud, 1F);
    }
    void Shoot()
    {
        
        Instantiate(bullet, transform.position + transform.right * posBullet.x + transform.up * posBullet.y, Quaternion.identity);

    }

    private void LookAtPlayer()
    {
        //�p�G �ĤHx �j�� ���ax ���N���a�b���� ����180
        if (transform.position.x > Player.transform.position.x)
        {
            transform.eulerAngles = Vector3.zero; 
        }
        //�_�h �ĤHx �p�� ���ax �N�N���a�b�k�� ����0
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitBox")
        {
            EnemyHp = EnemyHp - PlayerATK;
            FlashRed();
            Player.GetComponent<PlayerStat>().playerHp += 1;
        }
    }

    void FlashRed()
    {
        rend.color = Color.red;
        Invoke("ResetColor", 0.1f);
    }
    void ResetColor()
    {
        rend.color = originalColor;
    }
}
