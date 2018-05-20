using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : obstacle {

	// Use this for initialization
	void Start () {
        mananger = GameObject.Find("Mananger").GetComponent<Mananger>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    protected override void DoWhitBullet() { }
    }
