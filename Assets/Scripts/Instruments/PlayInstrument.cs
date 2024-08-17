using UnityEngine;
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

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetSound(InstruVariant instruVar)
    {
        _tempInstru = instruVar;
        _soundSelected = _tempInstru.instruSound;
        Debug.Log(_soundSelected);
    }

    public void ConfirmInstrumentButton()
    {
        if(_audioSource != null && !GameManager.Instance.SoundsReplayerPlaying)
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
        }
    }
}
