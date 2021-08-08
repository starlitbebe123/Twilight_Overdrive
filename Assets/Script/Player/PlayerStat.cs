using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public GameObject Player;
    public float playerMaxHp;
    public int playerHp;
    Animator anim;
    Text textHp;
    GameObject FadeBlack;
    Animator FadeAnim;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = Player.GetComponent<Animator>();
        playerHp = 50;
        playerMaxHp = 100;
        FadeBlack = GameObject.Find("FadeBlack");
        FadeAnim = FadeBlack.GetComponent<Animator>();
        textHp = GameObject.Find("LifeText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textHp.text = playerHp.ToString();
       
        if (playerHp <= 10) textHp.color = new Color(255, 0, 0);
        else if (playerHp > 10) textHp.color = new Color(0, 255, 0);

        if (playerHp > playerMaxHp) playerHp = 100; 

        if (playerHp <= 0)
        {
            playerHp = 0; 
            anim.SetBool("isDead", true);
            Player.GetComponent<PlayerControl>().isDead = true;
            StartCoroutine(FadeOut()); 
        }
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        FadeAnim.SetBool("FadeOut", true);
        FadeBlack.GetComponent<FadeFunction>().SceneNumber = 3;
    }

}
