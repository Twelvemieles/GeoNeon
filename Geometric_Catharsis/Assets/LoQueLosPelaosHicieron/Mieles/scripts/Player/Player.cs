using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefabSolid;
    public GameObject bulletSpawn;
    public float force;
    [SerializeField]
    private Pooling pool;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            pool.GetBullet();
        }
    }

   // void Fire()
  //  {

  //      GameObject bullet = 
  //      bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * force, ForceMode.Impulse);
       

 //   }
}