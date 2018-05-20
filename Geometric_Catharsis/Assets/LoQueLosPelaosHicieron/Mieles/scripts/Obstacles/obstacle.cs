using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class obstacle : MonoBehaviour {
    protected GameObject bullet;
    protected Bullet bulletScript;
    [SerializeField]
    protected int puntos;
    protected Mananger mananger;
    

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            bullet = collision.gameObject;

            DoWhitBullet();
            DarQuitarPuntos(puntos);
        }
    }
    protected abstract void DoWhitBullet();
    protected void SacarBullet()
    {
        bullet = null;
    }
    protected void DarQuitarPuntos(double puntos)
    {
        mananger.SumarPuntaje(puntos);
    }

}
