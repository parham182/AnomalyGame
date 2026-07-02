using System;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("value")]
    [SerializeField] float doorOpenSpeed = 5f;
    [SerializeField] float targetAngle = -90f;
    [SerializeField] GameObject piviot;
    [Header("Sound")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip opendoor;
    [SerializeField] AudioClip closedoor;
    
    
    Quaternion closedRot;
    Quaternion openRot;

    bool isOpen;

    void Start()
    {
        closedRot = piviot.transform.rotation;
        openRot = quaternion.Euler(0, targetAngle, 0);
    }

    public void Interact()
    {
        isOpen = !isOpen;
    }

    void Update()
    {
        DoorHandeler();
    }

    void DoorHandeler()
    {
        Quaternion target = isOpen ? openRot : closedRot;

        piviot.transform.rotation = Quaternion.Slerp(piviot.transform.rotation, target, doorOpenSpeed * Time.deltaTime);
    }
}
