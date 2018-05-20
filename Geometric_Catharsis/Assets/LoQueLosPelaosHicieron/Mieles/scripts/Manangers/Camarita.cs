using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camarita : MonoBehaviour {
    public float tiempoEfectoIni = 3f;
    private float elapsedTime = 0;
    private bool cinematic = true;
    private float elapsedTimeMove = 0;
    [SerializeField]
    private CameraMananger cameraMananger;
    [SerializeField]
    private Transform inicial, final;


    // Use this for initialization
    void Start () {

        transform.position = inicial.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (elapsedTime <= tiempoEfectoIni)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {

            elapsedTimeMove += Time.deltaTime;
            if (elapsedTimeMove <= tiempoEfectoIni)
            {
                transform.position = Vector3.Lerp(inicial.position, final.position, elapsedTimeMove / tiempoEfectoIni);
               
            }
            else
            {
                if (cinematic == true)
                {
                    cinematic = false;
                    cameraMananger.ShowOverheadView();
                }
            }

           
        }


    }
}
