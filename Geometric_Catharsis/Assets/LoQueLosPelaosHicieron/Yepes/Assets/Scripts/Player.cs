using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float velocidad_movimiento;
    [SerializeField]
    private float velocidad_salto;
    [SerializeField]
    private int vida = 100;
    [SerializeField]
    private Slider barra_vida;
    [SerializeField]
    private KeyCode tecla_derecha;
    [SerializeField]
    private KeyCode tecla_izquiera;
    [SerializeField]
    private KeyCode tecla_frente;
    [SerializeField]
    private KeyCode tecla_atras;
    [SerializeField]
    private KeyCode salto_tecla;
    [SerializeField]
    private int orientacion; // 1 o -1
    [SerializeField]
    private AudioClip sonidoRecuperacion;
    [SerializeField]
    private AudioClip sonidoAbsorcion;
    [SerializeField]
    private AudioClip sonidoSalto;

    private AudioSource reproductor;
    private Rigidbody rb;
    private float hp = 0;
    private float daño;
    private bool saltar = true;
    private float vida_max;

    public float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Hp = vida/100;
        vida_max = vida / 100;
        barra_vida.value = Hp;
        reproductor = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Movimiento
        if(Input.GetKey(tecla_derecha))
        {
            Moverse(1, 0);
        }
        if (Input.GetKey(tecla_izquiera))
        {
            Moverse(-1, 0);
        }
        if (Input.GetKey(tecla_frente))
        {
            Moverse(0,1);
        }
        if (Input.GetKey(tecla_atras))
        {
            Moverse(0, -1);
        }

        //Salto
        if (Input.GetKeyDown(salto_tecla) && saltar)
        {
            Saltar();
            saltar = false;
            reproductor.clip = sonidoSalto;
            reproductor.Play();
        }

        //Vida
        barra_vida.value = Hp;
        if(Hp > vida)
        {
            Hp = vida_max;
        }
        
    }

    private void Moverse(int x,int z)
    {
        x *= orientacion;
        z *= orientacion;
        Vector3 direccion = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        transform.position = Vector3.MoveTowards(transform.position, direccion, velocidad_movimiento * Time.deltaTime);
    }

    private void Saltar()
    {
        Vector3 direccion = new Vector3(0, transform.position.y +0.1f, 0);
        rb.AddForce(direccion * velocidad_salto, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bala")
        {
            daño = 20;
            daño = daño / 100;
            Hp -= daño;
            Debug.Log(gameObject.name + " grita:OUCH! " + " " + daño);
        }

        if (other.gameObject.tag == "Suelo")
        {
            saltar = true;
        }

        if (other.gameObject.tag == "PowerUp")
        {

            if (Hp < vida_max)
            {
                hp += 0.5f;
                Debug.Log("Vida recuperada");
                reproductor.clip = sonidoRecuperacion;
                reproductor.Play();
            }

            if (Hp >= vida_max)
            {
                reproductor.clip = sonidoAbsorcion;
                reproductor.Play();
            }     
        }

        if (other.gameObject.tag == "Muerte")
        {
            Hp = 0;
        }


    }

   
}
