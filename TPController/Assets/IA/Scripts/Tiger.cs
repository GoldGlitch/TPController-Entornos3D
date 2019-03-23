using UnityEngine.AI;
using UnityEngine;

public class Tiger : MonoBehaviour
{

    public GameObject Target;
    public NavMeshAgent Agent;

    [Header("audioSettings")]
    public AudioSource audioSource;
    public AudioClip CreepingSound;
    public AudioClip rugido;
    public AudioClip none;
    //public AudioManager audioManger;

    [Header("Settings")]

    public float distance;
    public float idleDistance = 30;
    public float creepDistance = 18;
    public float runDistance = 10;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Animation>().Play("Idle", PlayMode.StopAll);
    }
    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(Target.transform.position, transform.position);

        #region animSettings
        if (distance > idleDistance)
        {
            if (!GetComponent<Animation>().IsPlaying("Idle")){

                GetComponent<Animation>().Play("Idle", PlayMode.StopAll);
            }
          
        }
        else if (distance < creepDistance && distance > runDistance)
        {
            if (!GetComponent<Animation>().IsPlaying("Creep"))
            {
                GetComponent<Animation>().Play("Creep", PlayMode.StopAll);
                audioSource.clip = CreepingSound;
                audioSource.loop = false;
                audioSource.Play();
                //FindObjectOfType<AudioSource>().Play("");
            }
            Agent.SetDestination(Target.transform.position);
            Agent.speed = 1f;

        }
        else if (distance <= runDistance)
        {
            if (!GetComponent<Animation>().IsPlaying("Run"))
            {
                GetComponent<Animation>().Play("Run", PlayMode.StopAll);
                audioSource.clip = none;
                audioSource.Play();
                //FindObjectOfType<AudioSource>().Play("");
            }
            Agent.SetDestination(Target.transform.position);
            Agent.speed = 3f;

        }
        #endregion
    }
}
