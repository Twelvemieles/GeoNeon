using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour {
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private int pooledAmount ;
   private List<GameObject> bullets;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    protected Mananger mananger;
    public int PooledAmount
    {
        get
        {
            return pooledAmount;
        }

        set
        {
            pooledAmount = value;
        }
    }

    // Use this for initialization
    void Start () {
        mananger = GameObject.Find("Mananger").GetComponent<Mananger>();
        bullets = new List<GameObject>();
        for (int i = 0; i  < PooledAmount; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bullets.Add(obj);

            ;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void  GetBullet()
    {
    
         Player script = GameObject.Find("Player").GetComponent <Player>();
        for (int i = 0;  i < bullets.Count; i ++)
        {
            Bullet BullScript = bullets[i].GetComponent<Bullet>();
            if(!bullets[i].activeInHierarchy && BullScript.Muerta == false)
            {
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = player.transform.rotation;
                bullets[i].SetActive(true);
                var bala = bullets[i];
                
                bala.GetComponent<Rigidbody>().AddForce(bala.transform.forward * script.force, ForceMode.Impulse);
                mananger.Municion--;
                mananger.UpdateMunicion();
                break;


            }
          
        }
        
    }
}
