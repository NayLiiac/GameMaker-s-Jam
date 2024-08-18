using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [field: SerializeField]
    [Tooltip("Current Level")]
    public int CurrentLevel { get; private set; }

    [field: SerializeField]
    [Range(0, 5)]
    [Tooltip("Minimum Number of Sounds per Level")]
    public int BaseInstrumentNumberPerLevel;

    /// <summary>
    /// Used to know if the Instrument Replayer is playing the sounds to make
    /// </summary>
    [field: SerializeField]
    public bool SoundsReplayerPlaying;
    public bool GameLost;

    [SerializeField]
    private UserInterfaceMain _uIMain;
    [Space(15)]

    [Tooltip("List of all available sounds")]
    public Instrument[] InstrumentList;

    [Space(10)]
    [Tooltip("Current Level Sounds to Make")]
    [SerializeField]
    private List<InstruVariant> Level = new List<InstruVariant>();

    [Space(10)]
    [Tooltip("Current Sounds that the player made")]
    public List<InstruVariant> CurrentSounds = new List<InstruVariant>();

    [SerializeField]
    private int _currentInstrumentNumber = 0;

    [SerializeField]
    [Range(0, 20)]
    private int _maxInstrumentNumber = 0;

    public event Action<InstruVariant> OnInstrumentPlayed;

    public void CreateLevel()
    {
        CurrentSounds.Clear();
        Level.Clear();
        _currentInstrumentNumber = 0;
        _currentInstrumentNumber = CurrentLevel + BaseInstrumentNumberPerLevel;
        if(_currentInstrumentNumber > _maxInstrumentNumber)
        {
            _currentInstrumentNumber = _maxInstrumentNumber;
        }

        for (int i = 0; i < _currentInstrumentNumber; i++)
        {
            int randomValue = UnityEngine.Random.Range(0, InstrumentList.Length);
            Level.Add(InstrumentList[randomValue].variants[UnityEngine.Random.Range(0, InstrumentList[randomValue].variants.Count)]);
        }
        Debug.Log("Level Created");
    }

    public void CheckLevel()
    {
        if (CurrentSounds.Count == Level.Count)
        {
            bool levelComplete = true;
            for (int i = 0; i < Level.Count; i++)
            {
                for (int j = 0; j < Level.Count; j++)
                {
                    if (CurrentSounds[i].type != Level[i].type || CurrentSounds[i].soundType != Level[i].soundType)
                    {
                        levelComplete = false;
                        break;
                    }
                }

            }

            if (!levelComplete)
            {
                Debug.Log("Skill Issue");
                CurrentSounds.Clear();
                _uIMain.HealthScript.SetHealth(_uIMain.HealthScript.HealthPoints - 1);
                if (GameLost)
                {
                    _uIMain.CurtainAnim.SetTrigger("Close");
                    _uIMain.PlayButton.gameObject.SetActive(true);
                    _uIMain.QuitButton.gameObject.SetActive(true);

                    _uIMain.InstruSetter.SetButtonsAndSliderActivity(false);
                    _uIMain.InstruReplayer.SetActiveReplayerButton(false);

                    CurrentLevel = 1;
                    _uIMain._gameLost.SetActive(true);
                }
            }
            else
            {
                LevelCompleted();
            }
        }
    }

    public void LevelCompleted()
    {
        Debug.Log("Bravo");
        CurrentLevel++;

        _uIMain.CurtainAnim.SetTrigger("Close");

        _uIMain.PlayButton.gameObject.SetActive(true);
        _uIMain.QuitButton.gameObject.SetActive(true);
        _uIMain._levelWon.SetActive(true);

        _uIMain.InstruSetter.SetButtonsAndSliderActivity(false);
        _uIMain.InstruReplayer.SetActiveReplayerButton(false);
    }

    public List<InstruVariant> GetLevelSoundList()
    {
        return Level;
    }

    public void InstrumentPlayed(InstruVariant variant)
    {
        OnInstrumentPlayed?.Invoke(variant);
    }
}
