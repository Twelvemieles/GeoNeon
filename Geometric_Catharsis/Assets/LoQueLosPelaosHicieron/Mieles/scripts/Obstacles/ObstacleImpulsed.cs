using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleImpulsed : obstacle
{


    [SerializeField]
    private float forceShoot;
    // Use this for initialization
    void Start()
    {
        if (forceShoot == 0)
        {
            forceShoot = 5;
        }
        mananger = GameObject.Find("Mananger").GetComponent<Mananger>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void DoWhitBullet()
    {
        //Debug.Log(bullet.tag);
        //var XBullet = ;
        //var ZBullet = ;
        if ((bullet.transform.GetComponent<Rigidbody>().velocity.z < 12) && (bullet.transform.GetComponent<Rigidbody>().velocity.x < 12) && (bullet.transform.GetComponent<Rigidbody>().velocity.x > -12) && (bullet.transform.GetComponent<Rigidbody>().velocity.z > -12))
        {
            //Vector3 dir =new Vector3(bulletScript.Z1, 0f, bulletScript.X1);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
        }

        SacarBullet();
    }
}
