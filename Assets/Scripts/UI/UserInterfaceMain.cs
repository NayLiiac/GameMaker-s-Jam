using System.Collections;
using TMPro;
using UnityEngine;

public class UserInterfaceMain : MonoBehaviour
{
    public InstrumentSetter InstruSetter;
    public InstrumentReplayer InstruReplayer;

    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    [Range(0.5f, 10f)]
    private float _waitingTime;

    private void Start()
    {
        _levelText.text = "Level " + GameManager.Instance.CurrentLevel.ToString();
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
        // Fade the background
        yield return _waitingTime / 2;

        InstruReplayer.ReplayRequiredSounds();

        yield return _waitingTime;
        InstruSetter.SetButtonsAndSliderActivity(true);
        InstruReplayer.SetActiveReplayerButton(true);
    }
}
