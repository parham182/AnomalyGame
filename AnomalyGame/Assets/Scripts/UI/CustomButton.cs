using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Animator buttonAnimator;
    [Header("Sound Effects")]
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip clickClip;

    [SerializeField] private UnityEvent onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        UISound.instance.PlaySound(clickClip);
        onClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonAnimator.SetBool("IsHovering", true);
        UISound.instance.PlaySound(hoverClip, 6);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonAnimator.SetBool("IsHovering", false);
    }
}
