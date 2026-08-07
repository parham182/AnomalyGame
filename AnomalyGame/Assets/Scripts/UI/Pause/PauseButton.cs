using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button pauseButton;

    [SerializeField] private Volume globalVolume;

    private DepthOfField depthOfField;

    void Awake()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(OnPauseClicked);
    }

    private void Start()
    {
        globalVolume.profile.TryGet(out depthOfField);
    }

    void OnPauseClicked()
    {
        depthOfField.focusDistance.value = 0.01f;
        PauseManager.Instance.TogglePause();
    }

    void OnDestroy()
    {
        pauseButton.onClick.RemoveListener(OnPauseClicked);
    }
}