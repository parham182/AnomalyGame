using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip changeSceneClip;

    public static SceneController instance;
    private void Awake() { instance = this; }

    public void StartAnimation()
    {
        animator.SetTrigger("LightToDark");
        UISound.instance.PlaySound(changeSceneClip);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("TestingScene");
    }
}
