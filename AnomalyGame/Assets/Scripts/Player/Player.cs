using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public FlashLight flashLight;
    public static Player instance;

    private void Awake() { instance = this; }
}
