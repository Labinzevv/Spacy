using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject levelMenu;
    public GameObject ship;
    bool forPause = true;
    bool forSound = true;
    public float volume;

    void Update()
    {
        if (forPause == true)
        {
            levelMenu.SetActive(false);
            Time.timeScale = 1;
        }
        if (forPause == false)
        {
            levelMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (ship == null)
        {
            levelMenu.SetActive(true);
        }
    }

    public void Pause()
    {
        forPause = !forPause;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SoundOnOff()
    {
        forSound = !forSound;
        if (forSound == true)
        {
            AudioListener.volume = 1;
        }
        if (forSound == false)
        {
            AudioListener.volume = 0;
        }
    }
}
