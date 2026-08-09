using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public GameObject loadingText;
    public GameObject startButton;
    public UiFader uiFader;

    public bool autoLoad = false;

    private AsyncOperation loadOperation;

    private IEnumerator Start()
    {
        uiFader.FadeOut(0.2f);
        loadOperation = SceneManager.LoadSceneAsync(1);
        loadOperation.allowSceneActivation = false;
        while (loadOperation.progress < 0.9f)
        {
            yield return null;
        }

        yield return StartCoroutine(WarmUp());

        if (autoLoad)
        {
            StartGame();
        } else
        {
            loadingText.SetActive(false);
            startButton.SetActive(true);
        }
    }

    private IEnumerator WarmUp()
    {
        yield return null;
    }

    public void StartGame()
    {
        uiFader.FadeIn(0.2f);
        Invoke("ChangeScene", 0.25f);
    }

    private void ChangeScene()
    {
        if (loadOperation != null)
        {
            loadOperation.allowSceneActivation = true;
        }
    }
}
