using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlJuego : MonoBehaviour {

    [SerializeField]
    private Player jugadorVerde;
    [SerializeField]
    private Player jugadorAzul;
    [SerializeField]
    private Text gameOverBlue;
    [SerializeField]
    private Text gameOverGreen;
    [SerializeField]
    private Text ganatesGreen;
    [SerializeField]
    private Text ganatesAzul;
    [SerializeField]
    private Image fondoDerrotaVerde;
    [SerializeField]
    private Image fondoDerrotaAzul;
    [SerializeField]
    private Image fondoVictoriVerde;
    [SerializeField]
    private Image fondoVictoriAzul;
    [SerializeField]
    private Text continuar;


    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update ()
    {
		if(jugadorAzul.Hp <= 0 && jugadorVerde.Hp > 0)
        {
            GanaGreen();
            Time.timeScale = 0;
        }

        if (jugadorAzul.Hp > 0 && jugadorVerde.Hp <= 0)
        {
            GanaBlue();
            Time.timeScale = 0;
        }

        if (jugadorAzul.Hp <= 0 && jugadorVerde.Hp <= 0)
        {
            PierdenTodos();
            Time.timeScale = 0;
        }
    }

    private void GanaBlue()
    {
        gameOverGreen.gameObject.SetActive(true);
        ganatesAzul.gameObject.SetActive(true);
        fondoVictoriAzul.gameObject.SetActive(true);
        fondoDerrotaVerde.gameObject.SetActive(true);
        continuar.gameObject.SetActive(true);
        
    }

    private void GanaGreen()
    {
        gameOverBlue.gameObject.SetActive(true);
        ganatesGreen.gameObject.SetActive(true);
        fondoVictoriVerde.gameObject.SetActive(true);
        fondoDerrotaAzul.gameObject.SetActive(true);
        continuar.gameObject.SetActive(true);
    }

    private void PierdenTodos()
    {
        gameOverGreen.gameObject.SetActive(true);
        gameOverBlue.gameObject.SetActive(true);
        fondoDerrotaVerde.gameObject.SetActive(true);
        fondoDerrotaAzul.gameObject.SetActive(true);
        continuar.gameObject.SetActive(true);
    }
}
