using System.Collections.Generic;
using UnityEngine;

public class TargetAI : MonoBehaviour
{
    public Vector3 targetLocation = Vector3.zero;
    public float speed = 5;

    public float length;
    public float radius;
    public int numOfRays;
    public LayerMask sightLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = targetLocation - transform.position;
        transform.position += directionToTarget.normalized * speed * Time.deltaTime;
        CheckRay();
    }

    public void SetInsensity(float value)
    {
        length = value * 5 + 10;
        numOfRays = Mathf.FloorToInt(value * 10f) + 10;
        radius = value * 30 + 45;
    }

    public List<GameObject> CheckRay()
    {
        List<GameObject> foundObject = new List<GameObject>();

        for (int i = 0; i < numOfRays; i++)
        {
            float halfRadius = radius / 2;
            float radiusFactor = radius / numOfRays;
            Vector3 direction = Quaternion.Euler(0, -halfRadius + (radiusFactor * i), 0) * transform.forward;
            Vector3 origin = transform.position;

            Physics.Raycast(origin, direction, out RaycastHit hit, length, sightLayer);
            Debug.DrawLine(origin, origin + direction * length, Color.red);

            if (hit.collider)
            {
                if (!foundObject.Contains(hit.collider.gameObject))
                {
                    foundObject.Add(hit.collider.gameObject);
                }
            }
        }

        return foundObject;
    }
   
}

