using UnityEngine;

public class UiNotif : MonoBehaviour
{
    public static UiNotif instance;
    private void Awake() { instance = this; }

    public void ShowNotif(GameObject notifObeject, float time = 3f)
    {
        notifObeject.SetActive(true);
        // if (time <= 0)
        // {
        //     notifObeject.SetActive(false);
        // }
    }
}
