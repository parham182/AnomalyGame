using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    private void Awake() { instance = this; }

    public float soundFxVolume;
}
