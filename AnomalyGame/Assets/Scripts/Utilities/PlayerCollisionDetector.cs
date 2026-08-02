using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionDetector : MonoBehaviour
{
    public UnityEvent onAction;

    int counter = 0;
    public void Execute()
    {
        if (counter > 1) return;
       
        onAction?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            counter++;
            Execute();
        }
    }

}
