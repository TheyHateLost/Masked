using UnityEngine;

public class CooldownEX : MonoBehaviour
{
    public float cooldown;
    private float lastTimeCasted;

    private void CastAbility()
    {         if (Time.time - lastTimeCasted < cooldown)
        {
            Debug.Log("Ability is on cooldown.");
            return;
        }
        lastTimeCasted = Time.time;
        Debug.Log("Ability Casted!");
    }
    
}
