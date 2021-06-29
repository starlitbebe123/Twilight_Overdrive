
using UnityEngine;

public class Dragonfly : MonoBehaviour
{
    public bool Dropping;
    public Vector3 playerPos;
    public float timer;
    Animator anim;
    public GameObject Bomb;
    public bool hasDropped;
    public float dist;
    bool startFlying;
    public Vector3 pos;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        startFlying = false;
        anim = gameObject.GetComponent<Animator>();
        Dropping = false;
        hasDropped = false;
       
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        pos = this.transform.position;
        float x1 = playerPos.x;
        float x2 = gameObject.transform.position.x;
        dist = Mathf.Floor(Mathf.Abs(x1 - x2));
        if (dist <= 30) startFlying = true;
        if(Dropping == false && startFlying == true) 
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }
        if (dist == 0)
        {
            Dropping = true;
        }
        if (Dropping == true)
        {


            timer += Time.deltaTime;
            if (timer >= 0.2f)
            {
                anim.SetBool("Release", true);
                DropTheBomb();
            }
            if (timer >= 1)
            {
                Dropping = false;
            }
        }
    }

    void DropTheBomb() 
    {
        if(hasDropped == false)
        Instantiate(Bomb, new Vector2(transform.position.x-0.5f, transform.position.y-2), Quaternion.identity);
        hasDropped = true;  
    }

}
