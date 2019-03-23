using UnityEngine.AI;
using UnityEngine;

public class Alien : MonoBehaviour {

    public GameObject Target;
    public NavMeshAgent Agent;
    Animator anim;

    bool idle;
    bool saludo;
    bool run;
    bool dance;

    string idleParam = "Idle";
    string runParam = "Run";
    string saludoParam = "Saludo";
    string danceParam = "Dancing";

    //public AudioManager audioManger;

    [Header("Settings")]

    public float distance;
    public float idleDistance = 30f;
    public float SaludoDistance = 18f;
    public float DanceDistance = 10f;
    public float followDistance = 6f;
    private float stopDistance = 2.5f;
    //public float runSpeed = 20;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(Target.transform.position, transform.position);

        #region animSettings
        if (distance > idleDistance)
        {
            if (!idle)
            {
                idle = true;
            }
            saludo = false;
            dance = false;
        }
        if (distance < SaludoDistance && distance > DanceDistance)
        {
            if (!saludo)
            {
                saludo = true;
                //FindObjectOfType<AudioSource>().Play("");
            }

            idle = false;
            dance = false;
            Agent.SetDestination(Target.transform.position);
            Agent.speed = 0f;

        }
        if (distance < DanceDistance)
        {
            if (!dance)
            {
                dance = true;
            }

            idle = false;
            saludo = false;
           

        }
        if(distance <= followDistance)
        {
            if (!run)
            {
                run = true;
             
            }

            Agent.SetDestination(Target.transform.position);
            Agent.speed = 3.5f;
            idle = false;
            saludo = false;
            dance = false;
        }
        if(Agent.isStopped == true)
        {
            idle = true;
        }
      
        anim.SetBool(idleParam, idle);
        anim.SetBool(saludoParam, saludo);
        anim.SetBool(danceParam, dance);
        anim.SetBool(runParam, run);
        #endregion
    }

}
