using TMPro;
using UnityEngine;

public class BoxMessage : MonoBehaviour
{
    [SerializeField] GameObject boxObject;
    [SerializeField] TMP_Text messageText;

    public static BoxMessage instance;
    private void Awake() { instance = this; }

    public void ShowMessage(string message, float showTime)
    {
        boxObject.SetActive(true);
        messageText.text = message;
        Invoke("HideMessage", showTime);
    }

    private void HideMessage()
    {
        boxObject.SetActive(false);
    }
}
