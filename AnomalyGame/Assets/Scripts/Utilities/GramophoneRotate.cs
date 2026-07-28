using UnityEngine;

public class GramophoneRotate : MonoBehaviour
{
    public float speed = 45f;
    public bool spinning;

    private void Update()
    {
        if (spinning)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }

    public void StartSpin()
    {
        spinning = true;
    }

    public void StopSpin()
    {
        spinning = false;
    }
}
