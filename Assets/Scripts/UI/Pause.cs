using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuObj;
    public GameObject settingsMenuObj;
    private bool voiceEnabled = true;
    public bool GameIsPaused = false;

    public void PauseButton()
    {
        if (GameIsPaused == false)
        {
            Paused();
            GameIsPaused = true;
        }
        else
        {
            Resumed();
            GameIsPaused = false;
        }
    }

    public void Resumed() // karakterin baktıgı yerde harekliği durduran ve devam ettiren kod bloğu
    {
        Time.timeScale = 1;
        pauseMenuObj.SetActive(false);
        settingsMenuObj.SetActive(false);
    }

    public void Paused()
    {
        Time.timeScale = 0;
        pauseMenuObj.SetActive(true);
        settingsMenuObj.SetActive(false);
    }

    public void SettingsMenu() //ayarlar menümüzü aktif eden kodumuz
    {
        pauseMenuObj.SetActive(false);
        settingsMenuObj.SetActive(true);
    }

    public void lowQualityButton() // çözünürlüğü değiştirmeyi sağladığımız kodumuz
    {
        QualitySettings.SetQualityLevel(0, true);
    }
    public void medQualityButton() // çözünürlüğü değiştirmeyi sağladığımız kodumuz
    {
        QualitySettings.SetQualityLevel(1, true);
    }
    public void highQualityButton() // çözünürlüğü değiştirmeyi sağladığımız kodumuz
    {
        QualitySettings.SetQualityLevel(2, true);
    }

    public void returnButton()
    {
        pauseMenuObj.SetActive(true);
        settingsMenuObj.SetActive(false);
    }

    public void AudioSettings() //ayarlar menümüzü aktif eden kodumuz
    {
        if (voiceEnabled == true)
        {
            AudioListener.volume = 0;
        }
        else if (voiceEnabled == false)
        {
            AudioListener.volume = 1;
        }
    }
}
