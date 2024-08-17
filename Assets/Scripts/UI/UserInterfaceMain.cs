using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceMain : MonoBehaviour
{
    public InstrumentSetter InstruSetter;
    public InstrumentReplayer InstruReplayer;
    public Animator CurtainAnim;

    [field : SerializeField]
    public Button PlayButton {  get; private set; }

    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    [Range(0.5f, 10f)]
    private float _waitingTime;

    private void Start()
    {
        InstruSetter.SetButtonsAndSliderActivity(false);
        InstruReplayer.SetActiveReplayerButton(false);
    }

    public void LevelAnnouncement()
    {
        StartCoroutine(StartingGame());
    }

    public IEnumerator StartingGame()
    {
        GameManager.Instance.CreateLevel();
        _levelText.text = "Level " + GameManager.Instance.CurrentLevel.ToString();
        CurtainAnim.SetTrigger("Open");
        yield return _waitingTime;

        InstruReplayer.ReplayRequiredSounds();

        yield return _waitingTime;
        InstruSetter.SetButtonsAndSliderActivity(true);
        InstruReplayer.SetActiveReplayerButton(true);
    }
}
