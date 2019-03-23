using UnityEngine.AI;
using UnityEngine;

public class Sheik : MonoBehaviour {

    public GameObject Target;
    public NavMeshAgent Agent;
    Animator anim;

    bool idle;
    bool laugh;
    bool run;

    string idleParam = "Idle";
    string laughParam = "Laugh";
    string runParam = "Run";

    [Header("audioSettings")]
    public AudioSource audioSource;
    public AudioClip Laughing;
    public AudioClip runningSound;
    private AudioClip none;
    //public AudioManager audioManger;

    [Header("Settings")]

    public float distance;
    public float idleEatingDistance = 30;
    public float laughDistance = 18;
    public float runDistance = 10;
    //public float runSpeed = 20;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(Target.transform.position, transform.position);

        #region animSettings
        if (distance > idleEatingDistance)
        {
            if (!idle)
            {
                idle = true;
                audioSource.clip = none;
                audioSource.loop = true;
                audioSource.Play();
            }
            laugh = false;
            run = false;
        }
        if (distance < laughDistance && distance > runDistance)
        {
            if (!laugh)
            {
                laugh = true;
                audioSource.clip = Laughing;
                audioSource.loop = true;
                audioSource.Play();
                //FindObjectOfType<AudioSource>().Play("");
            }

            idle = false;
            run = false;
            Agent.SetDestination(Target.transform.position);
            Agent.speed = 0f;

        }
        if (distance < runDistance)
        {
            if (!run)
            {
                run = true;
                audioSource.clip = runningSound;
                audioSource.loop = true;
                audioSource.Play();
            }

            idle = false;
            laugh = false;
            Agent.SetDestination(Target.transform.position);
            Agent.speed = 3.5f;

        }
        anim.SetBool(idleParam, idle);
        anim.SetBool(laughParam, laugh);
        anim.SetBool(runParam, run);
        #endregion
    }
}
