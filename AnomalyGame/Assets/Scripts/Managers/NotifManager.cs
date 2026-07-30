using System.Collections;
using RTLTMPro;
using TMPro;
using UnityEngine;

public class NotifManager : MonoBehaviour
{
    [SerializeField] GameObject notifObject;
    [SerializeField] RTLTextMeshPro notifText;

    public static NotifManager instance;
    private void Awake() { instance = this; }

    void Start()
    {
        notifObject.SetActive(false);
    }
    
    public void ShowNotif(string message, float showTime = 3)
    {
        StopAllCoroutines();
        StartCoroutine(Notif(message, showTime));
    }

    private IEnumerator Notif(string message, float showTime)
    {
        notifObject.SetActive(true);
        notifText.text = message;
        yield return new WaitForSeconds(showTime);

        notifObject.SetActive(false);
    }
}
