﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    public GameObject Player;
    public Animator anim;
    public bool hurtFromRight;
    public Rigidbody2D rgbd;
    public Image imgHp;
    public float playerHp;
    public float MaxHp;
    public AudioClip HurtAud;
    public AudioClip GoalSound;
    public AudioClip GoalMusic;
    AudioSource audioSource;
    public GameObject WinText;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = Player.GetComponent<Animator>();
        rgbd = Player.GetComponent<Rigidbody2D>();
        imgHp = GameObject.Find("HpFill").GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();


    }

    private void Update()
    {
        playerHp = Player.GetComponent<PlayerStat>().playerHp; 
        MaxHp = Player.GetComponent<PlayerStat>().playerMaxHp;
        imgHp.fillAmount = playerHp / MaxHp;
        if (playerHp <= 10) imgHp.color = new Color(255, 0, 0);
        else if (playerHp > 10) imgHp.color = new Color(0, 255, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(Player.GetComponent<PlayerControl>().isHurting == false && Player.GetComponent<PlayerControl>().isDead == false)
        {
            if (other.tag == "DamageBox")
            {
                anim.SetBool("Hurt", true);
                Player.GetComponent<PlayerControl>().isHurting = true;
                if (transform.position.x < other.transform.position.x)
                    hurtFromRight = true;
                else
                    hurtFromRight = false;
                Bounce();
                audioSource.PlayOneShot(HurtAud, 1F);
                Player.GetComponent<PlayerStat>().playerHp -= 10; 
                StartCoroutine(Recover());
                
            }
        }

        

    }

    void Bounce()
    {
        if (hurtFromRight)
            rgbd.velocity = new Vector2(-10, 0);
        else if (!hurtFromRight)
            rgbd.velocity = new Vector2(10, 0);
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Hurt", false);
        Player.GetComponent<PlayerControl>().isHurting = false; 
    }
}


