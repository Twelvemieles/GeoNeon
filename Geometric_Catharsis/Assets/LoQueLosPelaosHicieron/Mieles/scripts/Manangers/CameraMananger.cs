using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMananger : MonoBehaviour {
    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject canvasText;
    public Camera cinematicCamera;
    public Camera overheadCamera;
    public Camera GameOverCamera;
    private Mananger mananger;
    /** singleton
    public CameraMananger Instance { get; private set; }
    public int Value;
    //end

    //singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //end*/

    private void Start()
    {
        canvasText.SetActive(true);
        gameOverText.SetActive(false);
        mananger = GameObject.Find("Mananger").GetComponent<Mananger>();
        ShowFirstPersonView();
    }
    public void GameOverView()
    {
        print("yeado");
        cinematicCamera.enabled = false;
        GameOverCamera.enabled = true;
        overheadCamera.enabled = false;
        gameOverText.SetActive(true);
        canvasText.SetActive(false);
    }
    public void ShowOverheadView()
    {
        cinematicCamera.enabled = false;
        overheadCamera.enabled = true;
        GameOverCamera.enabled = false;
    }

    public void ShowFirstPersonView()
    {
        GameOverCamera.enabled = false;
        cinematicCamera.enabled = true;
        overheadCamera.enabled = false;
    }
    private void Update()
    {
        if (mananger.ActBullets <= 0)
        {
            
            GameOverView();
        }
    }
}
