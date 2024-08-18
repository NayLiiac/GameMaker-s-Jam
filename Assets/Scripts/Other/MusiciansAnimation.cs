using UnityEngine;

public class MusiciansAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _musicians;
    public InstrumentReplayer InstrumentReplayer;

    private void Start()
    {
        GameManager.Instance.OnInstrumentPlayed += InvokeAnim;
    }

    public void InvokeAnim(InstruVariant instruVariant)
    {
        AnimMusicians(instruVariant);
    }

    private void AnimMusicians(InstruVariant instru)
    {
        switch (instru.type)
        {
            case InstrumentType.Bass:
                // Play Bass Musician Anim
                
                break;
            case InstrumentType.Drum:
                // Play Drum Musician Anim

                break;
            case InstrumentType.Piano:
                // Play Piano Musician Anim
                _musicians.SetTrigger("Pianist");
                break;
            case InstrumentType.Guitar:
                // Play Guitar Musician Anim

                break;
            case InstrumentType.Violin:

                break;
            case InstrumentType.X

                : break;
        }
    }
}
