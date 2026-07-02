using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneController.instance.StartAnimation();
    }
}
