using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour, IPointerClickHandler
{
    private bool hasClicked = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hasClicked) return;

        hasClicked = true;
        PauseManager.Instance.TogglePause();
        Player.instance.uiFader.FadeIn(0.4f);
        Invoke("GoToMainMenu", 0.5f);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
