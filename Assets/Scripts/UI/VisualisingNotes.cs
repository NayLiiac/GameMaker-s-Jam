using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualisingNotes : MonoBehaviour
{
    [SerializeField]
    private List<Image> _notes = new List<Image>();

    private void Start()
    {
        GameManager.Instance.SendSpriteOnInstrumentPlayed += InvokeSpriteNote;
        CleaningNotes();
    }

    public void InvokeSpriteNote(InstruVariant noteInstru)
    {
        _notes[GameManager.Instance.CurrentSounds.Count - 1].gameObject.SetActive(true);
        _notes[GameManager.Instance.CurrentSounds.Count - 1].sprite = noteInstru.noteSprite;
    }

    public void CleaningNotes()
    {
        for(int i = 0; i < _notes.Count; i++)
        {
            _notes[i].sprite = null;
            _notes[i].gameObject.SetActive(false);
        }
    }
}
