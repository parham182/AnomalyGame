using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject optionUI;
    [SerializeField] GameObject mainOptionMenu;
    void Start()
    {
        optionUI.SetActive(false);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        mainOptionMenu.SetActive(false);
        optionUI.SetActive(true);
    }
}
