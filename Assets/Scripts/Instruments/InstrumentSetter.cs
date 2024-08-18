using UnityEngine;
using UnityEngine.UI;

public class InstrumentSetter : MonoBehaviour
{
    [field: SerializeField]
    public PlayInstrument InstrumentPlayer { get; private set; }

    [SerializeField]
    private Button _previousButton;
    [SerializeField]
    private Button _nextButton;
    [SerializeField] 
    private Button _playTestButton;
    [SerializeField]
    private Slider _soundScaler;

    /// <summary>
    /// minimum value of instrument list
    /// </summary>
    [SerializeField]
    private int _minValue;

    /// <summary>
    /// maximum value of instrument list
    /// </summary>
    [SerializeField]
    private int _maxValue;

    /// <summary>
    /// index in order to cycle instrument
    /// </summary>
    [SerializeField]
    private int _soundsIndex;   
    
    private void Start()
    {
        _soundsIndex = 0;
        _minValue = 0;
        _maxValue = GameManager.Instance.InstrumentList.Length;

        SetSoundViaIndex(_soundsIndex);
    }

    public void SetSoundViaIndex(int soundIndex)
    {
        InstrumentPlayer.SetSound(GameManager.Instance.InstrumentList[soundIndex].variants[(int)_soundScaler.value]);
        _playTestButton.image.sprite = GameManager.Instance.InstrumentList[soundIndex]._instruSprite;

        Debug.Log(GameManager.Instance.InstrumentList[soundIndex].variants[(int)_soundScaler.value]._name);
    }

    public void NextInstrument()
    {
        if(_soundsIndex + 1 < _maxValue)
        {
            SetSoundViaIndex(_soundsIndex + 1);
            _soundsIndex++;
        }
    }

    public void PrevInstrument()
    {
        if (_soundsIndex - 1 >= _minValue)
        {
            SetSoundViaIndex(_soundsIndex - 1);
            _soundsIndex--;
        }
    }

    public void SoundScaleInstrument()
    {
        SetSoundViaIndex(_soundsIndex);
    }

    public void SetButtonsAndSliderActivity(bool b)
    {
        _nextButton.enabled = b;
        _previousButton.enabled = b;
        _soundScaler.enabled = b;
        _playTestButton.enabled = b;
    }
}
