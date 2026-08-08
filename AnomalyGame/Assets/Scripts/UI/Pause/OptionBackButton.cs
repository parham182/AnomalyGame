using UnityEngine;
using UnityEngine.EventSystems;

public class OptionBackButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject mainPauseMenu;
    [SerializeField] GameObject optionMenu;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        SettingsManager.instance.SaveData();
        optionMenu.gameObject.SetActive(false);
        mainPauseMenu.SetActive(true);
    }
}
