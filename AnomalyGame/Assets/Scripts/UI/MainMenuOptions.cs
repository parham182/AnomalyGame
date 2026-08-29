using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField] UiFader uiFader;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] GameObject optionsBox;
    [SerializeField] GameObject tutorialBox;
    [SerializeField] GameObject aboutusBox;
    [SerializeField] GameObject uiCanvas;


    private bool hasStarted = false;

    private void Start()
    {
        uiFader.FadeOut();
    }

    public void OnStartClick()
    {
        if (hasStarted) return;

        hasStarted = true;
        uiFader.FadeIn(1);
        StartCoroutine(SoundManager.instance.StopMusicSlowly());
        Invoke(nameof(ChangeScene), 1.5f);
    }

    public void OnOptionsClick()
    {
        PauseManager.Instance.IsPaused = true;
        optionsBox.SetActive(true);
        uiCanvas.SetActive(false);
    }

    public void OnAboutUsClick()
    {
        aboutusBox.SetActive(true);
        uiCanvas.SetActive(false);
    }

    public void OnTutorialClick()
    {
        tutorialBox.SetActive(true);
        uiCanvas.SetActive(false);
    }

    public void OnBackTutorialClick()
    {
        uiCanvas.SetActive(true);
        tutorialBox.SetActive(false);
    }

    public void OnnBackAboutUsClick()
    {
        aboutusBox.SetActive(false);
        uiCanvas.SetActive(true);
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
