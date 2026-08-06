using UnityEngine;

public class Floor : MonoBehaviour
{
    
    public bool isAnomaly = true;
    [SerializeField] private GameObject floorObject;

    public void EnableFloor() 
    {
        floorObject.SetActive(true);
    }

    public void DisableFloor()
    {
        floorObject.SetActive(false);
    }
}
