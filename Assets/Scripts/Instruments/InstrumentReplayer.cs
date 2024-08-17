using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ReplaySounds()
    {
        if (!GameManager.Instance.SoundsReplayerPlaying)
        {
            GameManager.Instance.SoundsReplayerPlaying = true;
            StartCoroutine(SoundsRequiredReplayer(GameManager.Instance.GetLevelSoundList()));
        }
    }

    public IEnumerator SoundsRequiredReplayer(List<InstruVariant> instru)
    {
        for(int i = 0; i < instru.Count; i++)
        {
            _soundsReplayer.clip = instru[i].instruSound;
            _soundsReplayer.Play();
            yield return new WaitForSeconds(_waitingTime);
        }

        GameManager.Instance.SoundsReplayerPlaying = false;
    }
}
