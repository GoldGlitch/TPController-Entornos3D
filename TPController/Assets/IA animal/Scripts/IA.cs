using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour {

    [Header("Settings")]
    public int tiempo;
    public float speed;

    private float y;

    private bool tiempoDeGiro;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        tiempo += 1;
        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, y, 0));

        if (tiempo >= Random.Range(100, 2500))
        {
            Girar();
            tiempo = 0;
            tiempoDeGiro = true;
        }
        if(tiempoDeGiro == true)
        {
            if (tiempo >= Random.Range(10, 30))
            {
                y = 0;
                tiempoDeGiro = false;
            }
        }
	}

    void Girar()
    {
        y = Random.Range(-3, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstaculos")
        {
            Girar();
        }
    }
}
