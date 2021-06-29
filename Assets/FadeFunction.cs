using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeFunction : MonoBehaviour
{
    public float SceneNumber;

    // Start is called before the first frame update
    void ChangeScene()
    { 
        if(SceneNumber == 0)
        {
            SceneManager.LoadScene(0);
            
        }

        else if (SceneNumber == 1)
        {
            SceneManager.LoadScene(1);
           
        }

        else if (SceneNumber == 2)
        {
            SceneManager.LoadScene(2);
        }

        else if (SceneNumber == 3)
        {
            SceneManager.LoadScene(3);
        }

    }
}
