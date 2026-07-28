using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Animator buttonAnimator;

    [SerializeField] private UnityEvent onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.instance.PlayClickSound();
        onClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // buttonAnimator.SetBool("IsHovering", true);
        // UISound.instance.PlaySound(hoverClip, 0.6f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // buttonAnimator.SetBool("IsHovering", false);
    }
}
