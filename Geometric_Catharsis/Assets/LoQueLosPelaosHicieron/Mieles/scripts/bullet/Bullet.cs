using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {
    [SerializeField]
    private bool muerta ;
    [SerializeField]
    protected int vida ;
   // [SerializeField]
  //  protected ParticleSystem particleChoque, particleDie, particleWin;
    [SerializeField]
    protected Mananger mananger;
    //particleChoque,particleDie,particleWin;
    protected float force = 15f;
                   
    protected void Start()
    {
        //particleDie.Stop();
       // particleChoque.Stop();
       // particleWin.Stop();
    }
    public bool Muerta
    {
        get
        {
            return muerta;
        }

        set
        {
            muerta = value;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RedZone")
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            mananger.Municion++;
            mananger.UpdateMunicion();
            gameObject.SetActive(false);
           // BeginparticleWin();


        }
        else
        {
            if (collision.gameObject.tag == "DamageObs")
            {
                vida--;


            }
            else
            {
                if (collision.gameObject.tag == "Sun")
                {
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                    mananger.Municion++;
                    mananger.UpdateMunicion();
                    gameObject.SetActive(false);
                   // BeginParticleDie();


                }
                else
                {
                  //  BeginParticleChoque();
                }
                
            }
        }
    }
    /**public void OnCollisionExit(Collision collision)
    {
        particleDie.Stop();
        particleChoque.Stop();
        particleWin.Stop();
    }*/
    protected void OnTriggerStay (Collider other)
    {
        
        if (other.gameObject.tag == "Gravity")
        {
            Gravitator obj = other.GetComponent<Gravitator>();
            var center = obj.Middle;
            var P1 = center.position;
            var Vect = P1 - transform.position;
            var Magn = Vect.magnitude;

            var Dir = Vect / Magn;
            

            GetComponent<Rigidbody>().AddForce(Vect * (force - Magn), ForceMode.Acceleration);

        }
    }
    

    // Use this for initialization
    protected virtual void Awake () {
        Muerta = false;
        vida =  3;
        mananger = GameObject.Find("Mananger").GetComponent<Mananger>();
        

    }

    // Update is called once per frame
    protected virtual void Update ()
    {
       if (vida <= 0)
        {
           
            Muerta = true;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            gameObject.SetActive(false);
            vida = 3;
            mananger.UpdateBullets();
            


        }
       
   
    }
    /**
    protected void BeginParticleChoque()
    {
        if (particleChoque.isPlaying)
        {
            particleChoque.Stop();
        }
        else
        {
            particleChoque.Play();
        }
    }
    protected void BeginParticleDie()
    {
        if (particleDie.isPlaying)
        {
            particleDie.Stop();
        }
        else
        {
            particleDie.Play();
        }
    }
    protected void BeginparticleWin()
    {
        if (particleWin.isPlaying)
        {
            particleWin.Stop();
        }
        else
        {
            particleWin.Play();
        }
    }*///
    
}
