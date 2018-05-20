using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitator : MonoBehaviour {
    [SerializeField]
    private Transform middle;

    public Transform Middle
    {
        get
        {
            return middle;
        }

        set
        {
            middle = value;
        }
    }

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
