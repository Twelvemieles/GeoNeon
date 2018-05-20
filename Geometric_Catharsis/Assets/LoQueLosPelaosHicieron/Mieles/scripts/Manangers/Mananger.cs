using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Mananger : MonoBehaviour {

    
    [SerializeField]
    private Text scoreText,finalScore;
    [SerializeField]
    private Text BulletsText;
    
    [SerializeField]
    private Text municionText;
    [SerializeField]
    private Pooling poolScript;
    
    private double score;
    private int actBullets;
    [SerializeField]
    private float timeAdjust = 3;
    private bool veloz = false;
    [SerializeField]
    private Button timeButton;
    [SerializeField]
    private int municion;
    [SerializeField]
    private Sprite normalSprite , fastSprite ;
    public double Score
   
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public int ActBullets
    {
        get
        {
            return actBullets;
        }

        set
        {
            actBullets = value;
        }
    }

    public int Municion
    {
        get
        {
            return municion;
        }

        set
        {
            municion = value;
        }
    }



   



    // Use this for initialization
    void Start () {
        
        timeButton.GetComponent<Image>().sprite = fastSprite;
        actBullets = poolScript.PooledAmount + 1;
        Municion = poolScript.PooledAmount;
        
        UpdateBullets();
        UpdateMunicion();
    }
	
	// Update is called once per frame
	void Update () {
        
       
    }
    public void SumarPuntaje(double value)
    {

        score += value;
        UpdateScore();

        
    }
    
    void UpdateScore()
    {
        scoreText.text = "" + score;
        finalScore.text = "" + score;
    }
    public void UpdateBullets()
    {
        ActBullets--;
        BulletsText.text = "" + actBullets;
        
    }
    public void UpdateMunicion()
    {
        municionText.text = "" + municion;
    }

    public void TimeAdjustment()
    {
        if (veloz == false)
        {
            timeButton.GetComponent<Image>().sprite = normalSprite;
            Time.timeScale = timeAdjust;
        }
        else
        {
            timeButton.GetComponent<Image>().sprite = fastSprite;
            Time.timeScale = 1;
        }
        veloz = !veloz; 
        
    }
}
