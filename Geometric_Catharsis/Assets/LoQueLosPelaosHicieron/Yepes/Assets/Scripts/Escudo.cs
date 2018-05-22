using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour {

    [SerializeField]
    private int vida = 100;
    [SerializeField]
    private int daño = 0;
    [SerializeField]
    private AudioClip sonido_quebrar;
    [SerializeField]
    private AudioClip sonido_golpe;

    private AudioSource reproductor;

	// Use this for initialization
	void Start ()
    {
        reproductor = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(vida <= 0)
        {
            Destruir();
        }
	}

    private void Destruir()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Rigidbody rb = transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
            transform.GetChild(i).gameObject.tag = "Pared";
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            Destroy(gameObject, 2);
        }
        vida = 1;
        reproductor.clip = sonido_quebrar;
        reproductor.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            vida -= daño;
            reproductor.clip = sonido_golpe;
            reproductor.Play();
        }
    }
}
