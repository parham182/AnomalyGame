using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ResumeButton : MonoBehaviour, IPointerClickHandler
{
    private DepthOfField depthOfField;

    public void OnPointerClick(PointerEventData eventData)
    {
        PauseManager.Instance.Resume();
    }
}
