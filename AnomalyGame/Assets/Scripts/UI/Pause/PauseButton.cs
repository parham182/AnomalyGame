using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button pauseButton;
    
    void Awake()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(OnPauseClicked);
    }

    void OnPauseClicked()
    {
        SoundManager.instance.PlayClickSound();
        PauseManager.Instance.TogglePause();
    }

    void OnDestroy()
    {
        pauseButton.onClick.RemoveListener(OnPauseClicked);
    }
}