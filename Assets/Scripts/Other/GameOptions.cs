using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    public Animator OptionsAnimator;

    [Header("Volume Settings")]
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private Slider _audioSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    public void OpenOptionWindow()
    {
        OptionsAnimator.SetTrigger("Open");
    }

    public void CloseOptionWindow()
    {
        OptionsAnimator.SetTrigger("Close");
    }

    public void SetMusicVolume()
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(_audioSlider.value)*20);
        PlayerPrefs.SetFloat("MusicVolume", _audioSlider.value);
    }

    private void LoadVolume()
    {
        _audioSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume();
    }
}
