using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Animator buttonAnimator;
    public UnityEvent onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonAnimator.SetBool("IsHovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonAnimator.SetBool("IsHovering", false);
    }
}
