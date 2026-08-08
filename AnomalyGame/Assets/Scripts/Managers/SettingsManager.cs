using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sensitivitySlider;
    public static SettingsManager instance;

    public float soundFxVolume;
    public float musicSoundVolume;
    public float sensitivity;

    private void Awake() { instance = this; }

    private void Start()
    {
        LoadData();
        SoundManager.instance.UpdateSoundVolume();
    }

    public void LoadData() {
        SettingsData settingsData = new SettingsData();
        if (SaveLoadManager.CheckFileExists(SaveLoadManager.singleton.settingsDataFileName))
            SaveLoadManager.singleton.Load(settingsData, SaveLoadManager.singleton.settingsDataFileName);
        else SaveLoadManager.singleton.Save(settingsData, SaveLoadManager.singleton.settingsDataFileName);

        musicSoundVolume = settingsData.MusicSoundVolume;
        soundFxVolume = settingsData.SoundFxVolume;
        sensitivity = settingsData.Sensitivity;

        if (sensitivitySlider != null && musicVolumeSlider != null)
        {
            sensitivitySlider.value = sensitivity;
            musicVolumeSlider.value = musicSoundVolume;
        }
    }

    public void SaveData()
    {
        SettingsData settingsData = new SettingsData();
        settingsData.SoundFxVolume = soundFxVolume;
        settingsData.MusicSoundVolume = musicSoundVolume;
        settingsData.Sensitivity = sensitivity;

        SaveLoadManager.singleton.Save(settingsData, SaveLoadManager.singleton.settingsDataFileName);
        SoundManager.instance.UpdateSoundVolume();
    }

    public void UpdateData()
    {
        if (!PauseManager.Instance.IsPaused) return;

        sensitivity = sensitivitySlider.value;
        musicSoundVolume = musicVolumeSlider.value;
        SoundManager.instance.UpdateSoundVolume();
    }
}

