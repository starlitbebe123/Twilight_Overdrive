using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpFunction : MonoBehaviour {

    public GameObject Player;
    //public PlayerStat maxHp;
    //public PlayerStat Hp;
    public float maxHp;
    public float Hp;
    public Animator anim;
    GameObject phantom, bebe;

    // Use this for initialization
    void Start () {
        phantom = GameObject.Find("PhantomBlade");
        bebe = GameObject.Find("StarlitBebe");
    }
	
	// Update is called once per frame
	void Update () {

        Player = GameObject.FindGameObjectWithTag("Player");
        maxHp = Player.GetComponent<PlayerStat>().MaxHP;
        Hp = Player.GetComponent<PlayerStat>().HP;

        this.transform.localPosition = new Vector3( (-168 + 168 * (Hp / maxHp)), 0,0);
        //if(Player = phantom)
        //{
        //    anim.SetBool("Phantom", true);
        //    anim.SetBool("Bebe", false);
        //}
        //if (Player = bebe)
       // {
        //    anim.SetBool("Bebe", true);
        //    anim.SetBool("Phantom", false);
        //}

    }
}
