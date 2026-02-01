using System.Collections.Generic;
using UnityEngine;

public class TargetAI : MonoBehaviour
{
    public float MaxSpeed;
    private float Speed;

    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float SightRange;
    public float DetectionRange;

    public Rigidbody rB;
    public GameObject Target;

    private bool seePlayer;



    // Start is called before the first frame update
    void Start()
    {
        Speed = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //detect any players in range

        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var HitCollider in hitColliders)
            {

                if (HitCollider.tag == "Player")
                {
                    Target = HitCollider.gameObject;
                    seePlayer = true;
                }

            }

        }
        else
        {
            if (Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if (Hit.collider.tag != "Player")
                {
                    seePlayer = false;
                }
                else
                {
                    //calculate the direction

                    var Heading = Hit.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Direcation = Heading / Distance;

                    Vector3 Move = new Vector3(Direcation.x * Speed, 0, Direcation.z * Speed);
                    rB.linearVelocity = Move;
                    transform.forward = Move;
                }

            }
        }
    }


}

