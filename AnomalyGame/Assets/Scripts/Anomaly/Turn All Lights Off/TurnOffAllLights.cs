using System.Collections.Generic;
using UnityEngine;

public class TurnOffAllLights : MonoBehaviour
{
    [SerializeField] List<Light> lights = new List<Light>();
    [SerializeField] List<float> lightsIntens = new List<float>();
    [SerializeField] AudioClip turnOffSound;

    private bool hasTriggerd = false;
    private bool canTrigger = false;

    private void Start()
    {
        foreach(Light light in lights)
        {
            lightsIntens.Add(light.intensity);
        }
    }

    private void OnEnable()
    {
        canTrigger = true;
    }

    private void OnDisable()
    {
        canTrigger = false;
        hasTriggerd = false;

        foreach(Light light in lights)
        {
            light.intensity = lightsIntens[lights.IndexOf(light)];
        }
    }

    public void Trigger()
    {
        if (hasTriggerd || canTrigger == false) return;

        hasTriggerd = true;
        SoundManager.instance.PlaySoundEffect(turnOffSound, 0);

        foreach(Light light in lights)
        {
            light.intensity = 0.02f;
        }
    }
}
