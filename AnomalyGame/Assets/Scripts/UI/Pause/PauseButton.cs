using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button pauseButton;

    [SerializeField] private Volume globalVolume;


    void Awake()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(OnPauseClicked);
    }


    void OnPauseClicked()
    {
        PauseManager.Instance.TogglePause();
    }

    void OnDestroy()
    {
        pauseButton.onClick.RemoveListener(OnPauseClicked);
    }
}