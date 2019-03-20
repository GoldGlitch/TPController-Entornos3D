using UnityEngine;
using UnityEngine.AI;

public class IAGorilla : MonoBehaviour {

    public GameObject Target;
    public NavMeshAgent Agent;

    //Animation animation = new Animation();

    [Header("Settings")]

    public float distance;
    public float idleDistance = 10;
    public float runDistance = 5;
    //public float runSpeed = 20;

    // Update is called once per frame
    void Update () {

        distance = Vector3.Distance(Target.transform.position, transform.position);

        if (distance >= idleDistance)
        {
            //anim.Play("Idle Seating");
            GetComponent<Animation>().Play("Idle Seating", PlayMode.StopAll);
            Agent.speed = 1;
            //Agent.SetDestination(Target.transform.position);
            //Agent.speed = 3;
        }
        else if(distance < runDistance)
        {
            GetComponent<Animation>().Play("Run", PlayMode.StopAll);
            //anim.Play("Run");
            Agent.SetDestination(Target.transform.position);
            Agent.speed = 3;
        }
    }
}
