using UnityEngine;

public class PauseTheGame : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public AudioSource BGMSource;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameIsPaused = false;
        //pauseMenuUI.SetActive(false);
    }

   
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        BGMSource.Play();
        Player.GetComponent<PlayerControl>().enabled = true;
    }

    public void Pauseing() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        BGMSource.Pause();
        Player.GetComponent<PlayerControl>().enabled = false;
    }
}
