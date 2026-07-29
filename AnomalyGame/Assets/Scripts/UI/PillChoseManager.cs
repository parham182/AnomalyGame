using UnityEngine;

public class PillChoseManager : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject pillOptionUI;

    private void Start()
    {
        CloseOptions();
    }

    public void OpenOptions() {
        gameUI.SetActive(false);
        pillOptionUI.SetActive(true);
    }

    public void CloseOptions() {
        gameUI.SetActive(true);
        pillOptionUI.SetActive(false);
    }

    public void OnRedPillClick() {
        CloseOptions();
        LevelManager.instance.selectedPill = "RED";
        Player.instance.Sleep();
    }

    public void OnBluePillClick() {
        CloseOptions();
        LevelManager.instance.selectedPill = "BLUE";
        Player.instance.Sleep();
    }

    public void OnCancelClick() {
        CloseOptions();
    }
}
