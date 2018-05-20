using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : obstacle {

    private bool rotando = true;
    private float rotationY;
    [SerializeField]
    private float time = 1f;
    float elapsedTime;
    // Use this for initialization
    void Start () {
        mananger = GameObject.Find("Mananger").GetComponent<Mananger>();
        //rotationY = transform.rotation.eulerAngles.y;
       // StartCoroutine(Rotar());
    }
	
	// Update is called once per frame
	void Update () {
        if(rotando == true)
        {
            elapsedTime += Time.deltaTime;
            transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, new Vector3(0f, rotationY + 90f, 0f), elapsedTime / time);
        }
       
        if (elapsedTime >= time)
        {
            elapsedTime = 0;
            rotando = false;
            Invoke("RotarObstacle", time*2f);
        }
	}
   

    private void RotarObstacle()
    {
        rotationY = transform.localEulerAngles.y;
        rotando = true;
       
    }
        protected override void DoWhitBullet()
    {
       
    }
}

