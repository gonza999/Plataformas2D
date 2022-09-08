using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class UIManager : MonoBehaviour
{
    public GameObject OptionPnl;

    public AudioSource clip;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        OptionPnl.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        OptionPnl.SetActive(false);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void AnotherOptions()
    {
        //sound
        //graficos
        //controles
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }
}
