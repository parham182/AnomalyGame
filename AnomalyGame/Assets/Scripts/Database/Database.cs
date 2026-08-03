using System;

[Serializable]
public class SettingsData
{
    public float MusicSoundVolume;
    public float SoundFxVolume;
    public float Sensitivity;

    public SettingsData()
    {
        MusicSoundVolume = 0.7f;
        SoundFxVolume = 1f;
        Sensitivity = 0.3f;
    }
}