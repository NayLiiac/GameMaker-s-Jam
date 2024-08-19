using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// C'est moche mais bon, c'était le moyen le plus simple
public class AddSoundButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Sprite _addSoundButtonOriginalSprite;
    [SerializeField]
    private Sprite _addSoundButtonHighlightedSprite;

    [SerializeField]
    private Image _buttonSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _buttonSprite.sprite = _addSoundButtonHighlightedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _buttonSprite.sprite = _addSoundButtonOriginalSprite;
    }
}
