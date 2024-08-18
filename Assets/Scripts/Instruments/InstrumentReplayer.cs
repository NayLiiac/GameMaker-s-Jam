using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Replay the sounds required for the level
/// </summary>
public class InstrumentReplayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource _soundsReplayer;
    [SerializeField]
    [Range(0.5f, 10f)]
    private float _waitingTime;
    [SerializeField]
    private Button _requiredReplayerButton;
    [SerializeField]
    private Button _confirmedReplayerButton;

   

    public void ReplayRequiredSounds()
    {
        if (!GameManager.Instance.SoundsReplayerPlaying)
        {
            GameManager.Instance.SoundsReplayerPlaying = true;
            StartCoroutine(SoundsRequiredReplayer(GameManager.Instance.GetLevelSoundList()));
        }
    }

    public IEnumerator SoundsRequiredReplayer(List<InstruVariant> instru)
    {
        SetActiveReplayerButton(false);
        for(int i = 0; i < instru.Count; i++)
        {
            _soundsReplayer.clip = instru[i].instruSound;
            _soundsReplayer.Play();
            GameManager.Instance.InstrumentPlayed(instru[i]);

            yield return new WaitForSeconds(_waitingTime);
        }
        SetActiveReplayerButton(true);
        GameManager.Instance.SoundsReplayerPlaying = false;
    }

    public void ReplayConfirmedSounds()
    {
        if (!GameManager.Instance.SoundsReplayerPlaying && GameManager.Instance.CurrentSounds.Count > 0)
        {
            GameManager.Instance.SoundsReplayerPlaying = true;
            StartCoroutine(SoundsConfirmedReplayer(GameManager.Instance.CurrentSounds));
        }
    }

    public IEnumerator SoundsConfirmedReplayer(List<InstruVariant> instru)
    {
        SetActiveReplayerButton(false);
        for (int i = 0; i < instru.Count; i++)
        {
            _soundsReplayer.clip = instru[i].instruSound;
            _soundsReplayer.Play();
            GameManager.Instance.InstrumentPlayed(instru[i]);

            yield return new WaitForSeconds(_waitingTime / 2);

        }
        SetActiveReplayerButton(true);
        GameManager.Instance.SoundsReplayerPlaying = false;
    }

    public void SetActiveReplayerButton(bool b)
    {
        _requiredReplayerButton.enabled = b;
        _confirmedReplayerButton.enabled = b;
    }
}
