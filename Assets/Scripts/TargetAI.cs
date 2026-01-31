using UnityEngine;

public class TargetAI : MonoBehaviour
{
    public Vector3 targetLocation = Vector3.zero;
    public float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = targetLocation - transform.position;
        transform.position += directionToTarget.normalized * speed * Time.deltaTime;
    }
}

