using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {
    [SerializeField]
   private RaycastHit rhit;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject target;
    float max = 160f;
    float min = 20f;

    void Start()
    {
        target = new GameObject("target");
        cam = Camera.main;

    }


    void Update()
    {

        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out rhit))
        {

            transform.LookAt(rhit.point);

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);



        }
    }
        // Use this for initialization

    }
