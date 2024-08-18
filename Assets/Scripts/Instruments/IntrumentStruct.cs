using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class IntrumentStruct : MonoBehaviour
{
}
public enum InstrumentType
{
    Bass, Drum, Piano, Guitar, Violin, X,
}
public enum InstrumentSoundType
{
    LowPitchSound = 0,
    Normal = 1,
    HighPitchSound = 2,
}

[System.Serializable]
public struct Instrument
{
    public List<InstruVariant> variants;
    public Sprite _instruSprite;
}

[System.Serializable]
public struct InstruVariant
{
    public InstrumentType type;
    public InstrumentSoundType soundType;
    public AudioClip instruSound;
    public string _name;
    public GameObject MusicianLight;
}