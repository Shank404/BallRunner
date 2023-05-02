using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class SettingsController : MonoBehaviour
{
    private Resolution[] _resolutions;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private float _audioVolume;
    private bool _fullscreenMode = false;
    private bool _musicMute = false;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = MusicController.MusicInstance.GetAudioVolume();
        FillScreenResolutionDropdown();
        Screen.SetResolution(_resolutions[_resolutions.Length-1].width, _resolutions[_resolutions.Length-1].height, _fullscreenMode);

    }

    private void FillScreenResolutionDropdown()
    {
        
        resolutionDropdown.ClearOptions();
        _resolutions = Screen.resolutions;

        List<String> resolutionList = new List<String>();

        foreach (var resolution in _resolutions)
        {
            resolutionList.Add(resolution.ToString());
        }
        
        resolutionDropdown.AddOptions(resolutionList);


    }

    public void ChangeFullScreenModeToggle()
    {
        _fullscreenMode = !_fullscreenMode;
    }

    public void ChangeMusicMuteToggle()
    {
        _musicMute = !_musicMute;
    }


    public void ChangeSettings()
    {
        MusicController.MusicInstance.SetAudioVolume(slider.value);
        MusicController.MusicInstance.SetAudioMute(_musicMute, slider.value);
        Screen.fullScreen = _fullscreenMode;
        Screen.SetResolution(_resolutions[resolutionDropdown.value].width, _resolutions[resolutionDropdown.value].height, _fullscreenMode);
    }
    

}