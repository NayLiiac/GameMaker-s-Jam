using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    public Animator OptionsAnimator;

    [SerializeField]
    private Slider _audioSlider;

    public void OpenOptionWindow()
    {
        OptionsAnimator.SetTrigger("Open");
    }

    public void CloseOptionWindow()
    {
        OptionsAnimator.SetTrigger("Close");
    }
}
