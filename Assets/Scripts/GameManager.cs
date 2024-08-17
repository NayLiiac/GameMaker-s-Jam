using System.Collections.Generic;
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

    [Tooltip("List of all available sounds")]
    public Instrument[] InstrumentList;

    [Space(10)]
    [Tooltip("Current Level Sounds to Make")]
    [SerializeField]
    private List<InstruVariant> Level = new List<InstruVariant>();

    [Space(10)]
    [Tooltip("Current Sounds that the player made")]
    public List<InstruVariant> CurrentSounds = new List<InstruVariant>();

    public void CreateLevel()
    {
        Level.Clear();
        for (int i = 0; i < BaseInstrumentNumberPerLevel + CurrentLevel; i++)
        {
            int randomValue = Random.Range(0, InstrumentList.Length);
            Level.Add(InstrumentList[randomValue].variants[Random.Range(0, InstrumentList[randomValue].variants.Count)]);
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
                        Debug.Log("Don't Match");
                        levelComplete = false;
                        break;
                    }
                }

            }

            if (!levelComplete)
            {
                Debug.Log("Skill Issue");
                CurrentSounds.Clear();
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
    }

    public List<InstruVariant> GetLevelSoundList()
    {
        return Level;
    }
}
