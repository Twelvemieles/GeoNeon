using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Arma : MonoBehaviour {

    [SerializeField]
    private KeyCode tecla_disparo;
    [SerializeField]
    private GameObject bala_estandar;
    [SerializeField]
    private int numero_balas;
    [SerializeField]
    private float velocidad_balas;
    [SerializeField]
    private Transform salida_bala;
    [SerializeField]
    private Transform origen_bala;
    [SerializeField]
    private int cooldown_disparo;
    [SerializeField]
    private Text HUD_balas;
    [SerializeField]
    private AudioClip sonido_disparo;


    private AudioSource reproductor;
    private GameObject[] balas;
    private Rigidbody[] rb_balas;
    private int bala_actual;
    private int contador = 0;
    private bool recargar = false;

    // Use this for initialization
    void Start()
    {
        bala_actual = numero_balas;
        balas = new GameObject[numero_balas];
        rb_balas = new Rigidbody[numero_balas];
        reproductor = GetComponent<AudioSource>();
        CrearBala();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(tecla_disparo) && bala_actual > 0)
        {
            Disparar();
            bala_actual -= 1;
           

            if (recargar)
            {
                recargar = false;
            }
        }

        if(bala_actual == 0)
        {
            recargar = true;
        }

        if(recargar)
        {
            contador++;

            if (contador == cooldown_disparo)
            {
                contador = 0;
                bala_actual +=1;

                if (bala_actual == numero_balas)
                {
                    recargar = false;
                }
            }
        }

        //HUD

        HUD_balas.text = "Balas: " + bala_actual + "/" + numero_balas;
	}

    private void CrearBala()
    {
        for (int i = 0; i < numero_balas; i++)
        {
            GameObject clonBala = Instantiate(bala_estandar, new Vector3(bala_estandar.transform.position.x, bala_estandar.transform.position.y - i, 0), Quaternion.identity);
            balas[i] = clonBala;
            rb_balas[i] = clonBala.GetComponent<Rigidbody>();
        }
    }

    private void Disparar()
    {
        if(!balas[bala_actual - 1].activeInHierarchy)
        {
            balas[bala_actual - 1].SetActive(true);
        }

        rb_balas[bala_actual - 1].velocity = Vector3.zero;
        Vector3 direccion = salida_bala.position - transform.position;
        balas[bala_actual - 1].transform.position = origen_bala.position; ;
        rb_balas[bala_actual - 1].AddForce(direccion * velocidad_balas, ForceMode.Impulse);
        reproductor.clip = sonido_disparo;
        reproductor.Play();

    }
}
