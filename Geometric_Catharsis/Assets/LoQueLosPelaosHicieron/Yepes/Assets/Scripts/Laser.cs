using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private KeyCode tecla_especial;
    [SerializeField]
    private float energia;
    [SerializeField]
    private Transform origen;
    [SerializeField]
    private Transform salida;
    [SerializeField]
    private Slider eb;
    [SerializeField]
    private float costo;
    [SerializeField]
    private int cooldown;
    [SerializeField]
    private AudioClip sonido_laser;

    private AudioSource reproductor;
    private bool recargar = false;
    private int contador = 0;
    private float energia_restante;
    private LineRenderer laser;
    private bool reproducir = false;
    private int contadorSonido = 0;
	
    // Use this for initialization
	void Start ()
    {
        laser = GetComponent<LineRenderer>();
        energia_restante = energia/100;
        eb.value = energia_restante;
        costo /= 100;
        reproductor = GetComponentInParent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()

    {
        if (Input.GetKey(tecla_especial) && energia_restante > 0)
        {
            Disparar();
            energia_restante -= costo;
            recargar = false;
            reproducir = true;
        }
       
        if (Input.GetKeyUp(tecla_especial) || energia_restante < 0)
        {
            laser.SetPosition(0, Vector3.zero);
            laser.widthMultiplier = 0;
            reproducir = false;
            contadorSonido = 0;
        }

        eb.value = energia_restante;

        if(energia_restante < 0)
        {
            recargar = true;
        }

        if(recargar)
        {
            contador++;
            if(contador == cooldown)
            {
                energia_restante += 0.01f;
                contador = 0;
            }
        }
        
        if(reproducir)
        {
            contadorSonido++;

            if (contadorSonido == 1)
            {
                reproductor.clip = sonido_laser;
                reproductor.Play();
            }
        }
    }

    private void Disparar()
    {
        laser.SetPosition(0, origen.position);
        laser.widthMultiplier = 1;
        RaycastHit hit;
        Vector3 direccion = salida.position - origen.position;
        direccion.Normalize();

        Debug.DrawRay(origen.position, direccion, Color.yellow);

        if (Physics.Raycast(origen.position,direccion, out hit))
        {
            if (hit.collider)
            {
                laser.SetPosition(1, hit.point);

                if(hit.collider.gameObject.GetComponent<Player>() != null)
                {
                    Player enemigo = hit.collider.gameObject.GetComponent<Player>();
                    enemigo.Hp -= 0.01f;
                }       
            }         
        }

        else laser.SetPosition(1, direccion * 1000);

    }
}
