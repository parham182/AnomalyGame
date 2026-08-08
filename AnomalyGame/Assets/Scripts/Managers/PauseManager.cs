using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] AudioSource ambianceSound;
    public static PauseManager Instance;
    public GameObject pausePanel;
    public GameObject mainUi;
    public bool IsPaused { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void TogglePause()
    {
        if (IsPaused) Resume();
        else Pause();
    }

    public void Pause()
    {
        IsPaused = true;
        // Time.timeScale = 0f;
        pausePanel.SetActive(true);
        mainUi.SetActive(false);
        // ambianceSound.Pause();
    }

    public void Resume()
    {
        IsPaused = false;
        // Time.timeScale = 1f;
        pausePanel.SetActive(false);
        mainUi.SetActive(true);
        // ambianceSound.Play();
    }
}