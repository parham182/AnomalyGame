using UnityEngine;
using UnityEngine.SceneManagement;

public class Slender : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Transform jumpscareCameraPos;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Jumpscare();
        }
    }

    public void Jumpscare()
    {
        // disable controllers
        Player.instance.DisableControl();
        // reset camera position
        Camera.main.transform.SetParent(jumpscareCameraPos);
        Camera.main.transform.position = jumpscareCameraPos.position;
        Camera.main.transform.rotation = jumpscareCameraPos.rotation;
        // start jumpscare animation
        animator.SetTrigger("Jumpscare");
        // scream sound
        audioSource.Play();
    }

    public void FadeOut()
    {
        Player.instance.uiFader.FadeIn(1);
        StartCoroutine(SoundManager.instance.StopMusicSlowly(audioSource, 0.4f));
        Invoke("RespwnPlayer", 1.1f);
    }

    private void RespwnPlayer()
    {
        Player.instance.Respawn();
    }
}
