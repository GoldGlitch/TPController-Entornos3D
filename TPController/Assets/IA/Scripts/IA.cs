using UnityEngine.AI;
using UnityEngine;

public class IA : MonoBehaviour {

    [Header("Settings")]
    public int tiempo;
    public float speed;
    public Transform Guarida;
    public NavMeshAgent agent;

    [Header("estados")]
    public bool idle;
    public bool andar;
    public bool asustado;
    public int Estado = 1;

    bool Cambio;

    private float y;
    private bool tiempoDeGiro;

	// Update is called once per frame
	void FixedUpdate () {
        tiempo += 1;
        #region controlEstados
        if (Estado == 1)
        {
            idle = true;
            andar = false;
            asustado = false;
        }
        else if (Estado == 2)
        {
            idle = false;
            andar = true;
            asustado = false;


        }
        else if (Estado == 3)
        {
            idle = false;
            andar = false;
            asustado = true;
        }
        #endregion

        if (andar == true)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, y, 0));
            GetComponent<Animation>().Play("Walk", PlayMode.StopAll);
            if (tiempo >= Random.Range(100, 2500))
            {
                Girar();
                tiempo = 0;
                tiempoDeGiro = true;
            }
            if (tiempoDeGiro == true)
            {
                if (tiempo >= Random.Range(10, 30))
                {
                    y = 0;
                    tiempoDeGiro = false;
                }
            }
            
        }
        else if (idle == true)
        {
            GetComponent<Animation>().Play("Idle", PlayMode.StopAll);
        }
        else if(asustado == true)
        {
            agent.SetDestination(Guarida.position);
            GetComponent<Animation>().Play("Run Fast", PlayMode.StopAll);
            if (tiempo > Random.Range(500, 1000))
            {
                Estado = 1;
            }
        }
        
	}

    void Girar()
    {
        y = Random.Range(-3, 3);
    }

    public void CambiarEstado()
    {
        Estado = Random.Range(1, 2);
        if (Estado == 2)
        {
            Cambio = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstaculos")
        {
            Girar();
        }
        if(other.tag == "Player" && Cambio == true)
        {
            CambiarEstado();
            asustado = true;
        }
    }
}
