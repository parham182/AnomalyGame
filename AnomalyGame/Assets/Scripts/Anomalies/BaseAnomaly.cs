using UnityEngine;

public class BaseAnomaly : MonoBehaviour
{
    public int anomalyGroupID;

    // we call this when we want to enable anomaly
    public virtual void Instantiate() {}
}
