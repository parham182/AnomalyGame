using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ResumeButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Volume globalVolume;

    private DepthOfField depthOfField;
    
    private void Start()
    {
        globalVolume.profile.TryGet(out depthOfField);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        depthOfField.focusDistance.value = 10f;
        PauseManager.Instance.Resume();
    }
}
