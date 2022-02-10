using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNextLevel : MonoBehaviour
{
    public string[] MainMenu;
    public string[] Levels;

    public void Next()
    {
        if(SceneManager.GetActiveScene().name==MainMenu[0])
        {
            SceneManager.LoadScene(MainMenu[1]);
        }
    }
    public void Prev()
    {
        if(SceneManager.GetActiveScene().name==MainMenu[1])
        {
            SceneManager.LoadScene(MainMenu[0]);
        }
    }
    public void Play()
    {
        if(SceneManager.GetActiveScene().name==MainMenu[0])
        {
            SceneManager.LoadScene(Levels[0]);
        }
        else if(SceneManager.GetActiveScene().name==MainMenu[1])
        {
            SceneManager.LoadScene(Levels[1]);
        }
    }
    public void HomeButton()
    {
        Time.timeScale = 1f;
        if(SceneManager.GetActiveScene().name==Levels[0])
        {
            SceneManager.LoadScene(MainMenu[0]);
        }
        else if(SceneManager.GetActiveScene().name==Levels[1])
        {
            SceneManager.LoadScene(MainMenu[1]);
        }
        Time.timeScale = 1f;

    }
}
