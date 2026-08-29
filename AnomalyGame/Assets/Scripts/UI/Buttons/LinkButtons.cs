using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinkButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string link;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Application.OpenURL(link);
    }
}
