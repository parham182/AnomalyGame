using UnityEngine;

public class DoorKnock : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    int colideAmount = 0;

    public void Trigger()
    {
        colideAmount += 1;
        if (colideAmount == 2)
        {
            audioSource.Play();
        }
    }
}
