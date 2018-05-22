using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroMovil : MonoBehaviour {

    [SerializeField]
    private GameObject punto01;
    [SerializeField]
    private GameObject punto02;
    [SerializeField]
    private float velocidad = 0;
    [SerializeField]
    private float radio_atraccion;
    [SerializeField]
    private float fuerza_atraccion;

    private GameObject objetivo;

    // Use this for initialization
    void Start ()
    {
        objetivo = punto02;	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Vector3.Distance(transform.position,punto01.transform.position) <= 1)
        {
            objetivo = punto02;
        }

        if (Vector3.Distance(transform.position, punto02.transform.position) <= 1)
        {
            objetivo = punto01;
        }

        Moverse();
        Atraer();
    }

    private void Moverse()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, velocidad * Time.deltaTime);
    }

    private void Atraer()
    {
        Vector3 centro = transform.position;
        Collider[] colliders = Physics.OverlapSphere(centro, radio_atraccion);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.gameObject.transform.position = Vector3.MoveTowards(rb.gameObject.transform.position, transform.position, fuerza_atraccion * Time.deltaTime);
            }
        }
    }
}
