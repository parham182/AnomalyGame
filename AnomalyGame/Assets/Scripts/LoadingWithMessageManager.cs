using UnityEngine;

public class LoadingWithMessageManager : MonoBehaviour
{
    [SerializeField] UiFader uiFader;

    private void Start()
    {
        uiFader.FadeOut(0.25f);
    }
}
