using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoolDownController : MonoBehaviour
{
    public float coolDownTime = 5f; // Cooldown duration in seconds
    public float ablityTimer;
    private float cooldown;
    private void Update()
    {
        if (ablityTimer > 0)
            return;

        ablityTimer = cooldown;
        Debug.Log("Ability Used! Cooldown started.");

    }
}


