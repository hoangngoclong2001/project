using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelPause : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;
    public void Start()
    {
        PauseMenuPanel.SetActive(false);
    }

    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");

    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

    public void Mute()
    {
        SoundManager.Instance.MuteAll();
        Resume();
    }

    public void Unmute()
    {
        SoundManager.Instance.PlayAll();
        Resume();
    }
}
