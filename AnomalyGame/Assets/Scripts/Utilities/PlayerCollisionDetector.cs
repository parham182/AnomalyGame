using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionDetector : MonoBehaviour
{
    public UnityEvent onAction;

    public void Execute()
    {
        onAction?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") Execute();
    }
}
