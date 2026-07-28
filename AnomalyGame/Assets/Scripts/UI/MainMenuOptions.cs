using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField] UiFader uiFader;
    [SerializeField] AudioSource musicAudioSource;

    private void Start()
    {
        uiFader.FadeOut();
    }

    public void OnStartClick()
    {
        uiFader.duration = 1;
        uiFader.FadeIn();
        StartCoroutine(SoundManager.instance.StopMusicSlowly());
        Invoke(nameof(ChangeScene), 1.5f);
    }

    public void OnOptionsClick() {}

    public void OnAboutUsClick() {}

    public void OnExitGameClick()
    {
        uiFader.duration = 0.4f;
        uiFader.FadeIn();
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
