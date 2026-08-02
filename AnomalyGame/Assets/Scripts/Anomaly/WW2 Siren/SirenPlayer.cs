using UnityEngine;

public class SirenPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void PlaySiren()
    {
        audioSource.Play();
    }
}
