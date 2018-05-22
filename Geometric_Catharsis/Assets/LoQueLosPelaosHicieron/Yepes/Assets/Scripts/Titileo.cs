using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Titileo : MonoBehaviour {

    [SerializeField]
    private float suma;

    private bool cambiar = true;
    private Text texto;
    private Image imagen;
    private Color color;
    private int contador = 0;

	// Use this for initialization
	void Start ()
    {
        if (GetComponent<Text>() != null)
        {
            texto = GetComponent<Text>();
            color = texto.color;
        }

        if (GetComponent<Image>() != null)
        {
            imagen = GetComponent<Image>();
            color = imagen.color;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (cambiar)
        {
            color.a -= suma;
            contador++;

            if (contador == 50 )
            {
                contador = 0;
                cambiar = false;
            }
        }

        if (!cambiar)
        {
            color.a += suma;
            contador++;

            if (contador == 50)
            {
                contador = 0;
                cambiar = true;
            }
        }

        if (GetComponent<Text>() != null)
        {
            texto = GetComponent<Text>();
            texto.color = color;
        }

        if (GetComponent<Image>() != null)
        {
            imagen = GetComponent<Image>();
            imagen.color = color;
        }
    }
}
