using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.Audio;

public class IAGorilla : MonoBehaviour {

    public GameObject Target;
    public NavMeshAgent Agent;

    [Header("audioSettings")]
    private AudioSource audioSource;
    public AudioClip advertenciaSound;
    public AudioClip runningSound;
    public AudioClip none;
    //public AudioManager audioManger;

    [Header("Settings")]

    public float distance;
    public float idleEatingDistance = 30;
    public float advertenciaDistance = 18;
    public float runDistance = 10;
    //public float runSpeed = 20;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Animation>().Play("Seat Eating", PlayMode.StopAll);
    }
    // Update is called once per frame
    void Update () {

        distance = Vector3.Distance(Target.transform.position, transform.position);

        #region animSettings
        if (distance > idleEatingDistance)
        {
            GetComponent<Animation>().Play("Seat Eating", PlayMode.StopAll);
            audioSource.clip = none;
            audioSource.loop = false;
            audioSource.Play();
        }
        else if (distance < advertenciaDistance && distance > runDistance)
        {
            if (!GetComponent<Animation>().IsPlaying("Fight Idle 01"))
            {
                GetComponent<Animation>().Play("Fight Idle 01", PlayMode.StopAll);
                audioSource.clip = advertenciaSound;
                audioSource.loop = true;
                audioSource.Play();
                //FindObjectOfType<AudioSource>().Play("");
            }

        }
        else if (distance <= runDistance)
        {

            if(!GetComponent<Animation>().IsPlaying("Run"))
            {
                GetComponent<Animation>().Play("Run", PlayMode.StopAll);
                audioSource.clip = runningSound;
                audioSource.loop = true;
                audioSource.Play();
            }
            Agent.SetDestination(Target.transform.position);
            Agent.speed = 5f;

        }
        #endregion
    }


}
