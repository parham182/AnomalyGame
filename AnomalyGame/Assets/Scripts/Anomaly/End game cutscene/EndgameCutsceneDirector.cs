using UnityEngine;

public class EndgameCutsceneDirector : MonoBehaviour
{
    [SerializeField] Transform cameraPos;
    [SerializeField] GameObject slender;
    [SerializeField] GameObject messageCanvas;
    [SerializeField] float timer = 2f;
    public void Trigger()
    {
        // disable controllers
        Player.instance.DisableControl();

        // slender jump
        slender.SetActive(true);

        // lock camera
        Camera.main.transform.SetParent(cameraPos);
        Camera.main.transform.position = cameraPos.position;
        Camera.main.transform.rotation = cameraPos.rotation;
    }

    public void FadeIn()
    {
        Player.instance.uiFader.FadeIn(0.25f);
        Invoke("FadeOut", timer);
    }

    private void FadeOut()
    {
        messageCanvas.SetActive(true);
        Player.instance.uiFader.FadeOut(0.25f);
    }
}
