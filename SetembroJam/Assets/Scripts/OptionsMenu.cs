using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//arrumar proporção canvas

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer volMixer;

    public Slider volSlider;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    int m_resolution;

    void Awake() 
    {

    }

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution))
            {
                currentResolutionIndex = i;
            }
            
        }

        if(PlayerPrefs.HasKey("resolution"))
        {
            currentResolutionIndex = PlayerPrefs.GetInt("resolution");
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        volSlider.value = PlayerPrefs.GetFloat("volume", 0);
    }

    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("resolution", resolutionIndex);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        volMixer.SetFloat("volume", volume);
        //PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("quality", qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void RemovePrefs()
    {
        int currentResolutionIndex = 0;

        PlayerPrefs.DeleteKey("resolution");
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].Equals(Screen.currentResolution))
            {
                currentResolutionIndex = i;
            }
            
        }

        if (currentResolutionIndex != 0)
        {
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }

    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
