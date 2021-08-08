using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    private GameObject FadeBlack;
    Animator FadeAnim;
    private void Start()
    {
        FadeBlack = GameObject.Find("FadeBlack");
        FadeAnim = FadeBlack.GetComponent<Animator>();
 
    }
    // Start is called before the first frame update

    public void Title()
    {
        FadeAnim.SetBool("FadeOut", true);
        FadeBlack.GetComponent<FadeFunction>().SceneNumber = 0;
        Time.timeScale = 1f;
    }
    public void Tutorial()
    {
        FadeAnim.SetBool("FadeOut", true);
        FadeBlack.GetComponent<FadeFunction>().SceneNumber = 1;
    }
    public void Stage1() 
    {
        FadeAnim.SetBool("FadeOut", true);
        FadeBlack.GetComponent<FadeFunction>().SceneNumber  = 2;
        Time.timeScale = 1f;
    }

    public void Credit()
    {
        FadeAnim.SetBool("FadeOut", true);
        FadeBlack.GetComponent<FadeFunction>().SceneNumber = 4;
    }




    public void QuitGame()
    {
        Application.Quit(); 
    }

 
}
