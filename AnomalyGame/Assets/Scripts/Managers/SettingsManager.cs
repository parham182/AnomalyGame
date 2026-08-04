using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    public float soundFxVolume;
    public float musicSoundVolume;
    public float sensitivity;

    private void Awake() { instance = this; }

    private void Start()
    {
        LoadData();
    }

    public void LoadData() {
        SettingsData settingsData = new SettingsData();
        if (SaveLoadManager.CheckFileExists(SaveLoadManager.singleton.settingsDataFileName))
            SaveLoadManager.singleton.Load(settingsData, SaveLoadManager.singleton.settingsDataFileName);
        else SaveLoadManager.singleton.Save(settingsData, SaveLoadManager.singleton.settingsDataFileName);

        musicSoundVolume = settingsData.MusicSoundVolume;
        soundFxVolume = settingsData.SoundFxVolume;
        sensitivity = settingsData.Sensitivity;
    }

    public void SaveData()
    {
        SettingsData settingsData = new SettingsData();
        settingsData.SoundFxVolume = soundFxVolume;
        settingsData.MusicSoundVolume = musicSoundVolume;
        settingsData.Sensitivity = sensitivity;

        SaveLoadManager.singleton.Save(settingsData, SaveLoadManager.singleton.settingsDataFileName);
    }
}

