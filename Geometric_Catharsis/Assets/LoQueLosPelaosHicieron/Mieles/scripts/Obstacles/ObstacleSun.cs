using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSun : obstacle {
    
   
    [SerializeField]
    private Transform final;
    [SerializeField]
    private Transform inicial;
    private float elapsedTime;
    [SerializeField]
    private float time;


    // Use this for initialization
    void Start () {
        RespawnearEnemy();
        mananger = GameObject.Find("Mananger").GetComponent<Mananger>();
    }
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        transform.position = Vector3.Slerp(inicial.position, final.position, elapsedTime / time);
        
        if (transform.position == final.position)
        {
            RespawnearEnemy();
        }
        transform.LookAt(final);
    }
    public void RespawnearEnemy()
        {
            elapsedTime = 0;
            transform.position = inicial.position;
        }
    protected override void DoWhitBullet() { }
   
}
