using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenuUi;
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Resume()
    {
        Time.timeScale=1f;
        PauseMenuUi.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale=0f;
        PauseMenuUi.SetActive(true);
    }
    public void PlayAgain()
    {
        CoinScript.coins=0;
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu(string _name)
    {
        CoinScript.coins=0;
        Time.timeScale=1f;
        SceneManager.LoadScene(_name);
    }
    public void HomeButton()
    {
        CoinScript.coins=0;
        Time.timeScale=1f;
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        CoinScript.coins=0;
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
