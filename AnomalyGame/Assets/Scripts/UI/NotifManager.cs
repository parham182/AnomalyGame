using System.Threading;
using UnityEngine;

public class NotifManager : MonoBehaviour
{
    [SerializeField] float timeToHide = 3f;
    void Start()
    {
        // this.gameObject.SetActive(false);
    }
    void Update()
    {
        if (!gameObject.activeInHierarchy) return;
        
        timeToHide -= Time.deltaTime; 
        if (timeToHide <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
