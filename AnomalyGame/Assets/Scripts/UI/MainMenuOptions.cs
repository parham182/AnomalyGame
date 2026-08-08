using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField] UiFader uiFader;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] GameObject optionsBox;
    [SerializeField] GameObject uiCanvas;

    private void Start()
    {
        uiFader.FadeOut();
    }

    public void OnStartClick()
    {
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

    public void OnAboutUsClick() {}

    public void OnExitGameClick()
    {
        uiFader.FadeIn(0.4f);
        StartCoroutine(SoundManager.instance.StopMusicSlowly(0.4f));

        Invoke(nameof(ExitGame), 0.5f);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("GameLoop");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
