using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Adding Button Effect 
/// </summary>
public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    [Tooltip("Scale de base du bouton, récupérée automatiquement lors du Start()")]
    private Vector3 _scale;
    [SerializeField]
    [Tooltip("Valeur à laquelle la scale du bouton doit changer")]
    private Vector3 _scaleEffect;

    [SerializeField]
    private GameObject _tutorialBubble;

    private void Start()
    {
        _scale = transform.localScale;
    }

    /// <summary>
    /// Permet de savoir quand est-ce qu'on highlight un bouton
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = _scaleEffect;
        if(_tutorialBubble != null && GameManager.Instance.TutorialBubbles)
        {
            _tutorialBubble.SetActive(true);
        }
    }

    /// <summary>
    /// Permet de savoir quand un bouton n'est plus highlight
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData) 
    {
        this.transform.localScale = _scale;
        if(_tutorialBubble != null && GameManager.Instance.TutorialBubbles)
        {
            _tutorialBubble.SetActive(false);
        }
    }
}
