using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Used to play and add sounds required to complete the level
/// </summary>
public class PlayInstrument : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private InstruVariant _tempInstru;
    private AudioClip _soundSelected;

    [SerializeField]
    private Button _playTestButton;

    [Tooltip("waiting time before playing an instrument again")]
    [SerializeField]
    [Range(0f, 15f)]
    private float _waitingTime = 1.8f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetSound(InstruVariant instruVar)
    {
        _tempInstru = instruVar;
        _soundSelected = _tempInstru.instruSound;
    }

    public void ConfirmInstrumentButton()
    {
        if (_audioSource != null && !GameManager.Instance.SoundsReplayerPlaying)
        {
            _audioSource.PlayOneShot(_soundSelected);
            GameManager.Instance.CurrentSounds.Add(_tempInstru);
            GameManager.Instance.CheckLevel();
        }
    }

    public void PlayInstrumentButton()
    {
        if (_audioSource != null && !GameManager.Instance.SoundsReplayerPlaying)
        {
            _audioSource.PlayOneShot(_soundSelected);
            _playTestButton.enabled = false;
            StartCoroutine(WaitBeforePlayingInstrumentAgain());
        }
    }

    public IEnumerator WaitBeforePlayingInstrumentAgain()
    {
        yield return new WaitForSeconds(_waitingTime);
        _playTestButton.enabled = true;
    }
}
