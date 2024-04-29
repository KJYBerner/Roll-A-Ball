using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [Tooltip("to change boost direction, use a 1 or 0 in each x.y.z so for forwards use (0,01)")]

    public Vector3 boosterDirection = new Vector3(0, 1, 0);
    public float boosterPower = 250;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.attachedRigidbody.AddForce(boosterDirection * boosterPower);
        }
    }
}
