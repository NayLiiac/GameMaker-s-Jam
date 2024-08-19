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
                _musicians.SetTrigger("Bassist");
                break;
            case InstrumentType.Drum:
                // Play Drum Musician Anim
                _musicians.SetTrigger("Drummer");
                break;
            case InstrumentType.Piano:
                // Play Piano Musician Anim
                _musicians.SetTrigger("Pianist");
                break;
            case InstrumentType.Guitar:
                // Play Guitar Musician Anim
                _musicians.SetTrigger("Guitarist");
                break;
            case InstrumentType.Violin:

                break;
            case InstrumentType.X

                : break;
        }
    }
}
