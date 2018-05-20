using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Botones : MonoBehaviour {

    public string actualScene;
    public string LvlMieles,LvlYepes,LvlDiego;
    
    public string HomeScene;
    public string InfoScene;



    public void BotonRepetir ()
    {
        SceneManager.LoadScene(actualScene);

    }


    public void BotonLvlMieles()
    {
        SceneManager.LoadScene(LvlMieles);
    }
    public void BotonInfo()
    {
        SceneManager.LoadScene(InfoScene);
    }


    public void BotonLvlYepes()
    {
        SceneManager.LoadScene(LvlYepes);
    }
    public void BotonLvlDiego()
    {
        SceneManager.LoadScene(LvlDiego);
    }

    public void BotonHome()
    {
        SceneManager.LoadScene(HomeScene);
    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
