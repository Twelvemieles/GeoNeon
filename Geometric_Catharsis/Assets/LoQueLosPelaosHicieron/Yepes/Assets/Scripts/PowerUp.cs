using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private float fuerzaExplosion;
    [SerializeField]
    private float radioExplosion;
    [SerializeField]
    private float vida = 100;
    [SerializeField]
    private int daño = 0;
    [SerializeField]
    private int absorcion = 0;
    [SerializeField]
    private AudioClip sonidoimpacto;
    [SerializeField]
    private AudioClip sonidoExplosion;

    private AudioSource reproductor;
    private Light luz;
    private bool sonar = false;
    private int contador = 0;

	// Use this for initialization
	void Start ()
    {
        luz = GetComponentInChildren<Light>();
        reproductor = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        luz.intensity = vida / 10;

        if(vida <= 0)
        {
            Explotar();
            luz.range++;
            luz.intensity+=50;
            sonar = true;
            Destroy(gameObject, 3);    
        }

        if(sonar)
        {
            contador++;
            if(contador == 1)
            {
                reproductor.clip = sonidoExplosion;
                reproductor.Play();
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            vida -= daño;
            reproductor.clip = sonidoimpacto;
            reproductor.Play();
        }

        if (collision.gameObject.tag == "Player")
        {
            vida -= absorcion;
        }
    }

    private void Explotar()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radioExplosion);
        gameObject.tag = "Explo";

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(fuerzaExplosion, explosionPos, radioExplosion, 3.0F);
            } 
        }
       
    }
}
