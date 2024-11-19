using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // NIVEAU DE VIE
    public float vieMax = 100f;
    public float vieActuelle;

    //STATUS DU PERSONNAGE VIE ET COULEUR HUD
    public Image barreDeVie;
    public Color barreComplet = Color.green;
    public Color barre80 = Color.green;
    public Color barre60 = Color.yellow;
    public Color barre40 = Color.yellow;
    public Color barre20 = Color.red;
    public Color barre5 = Color.red;


    // Start is called before the first frame update
    void Start()
    {
        vieActuelle = 100;

        barreDeVie.color = barreComplet;

    }

    // Update is called once per frame
    void Update()
    {
        //diminue la vie
        vieActuelle -= 0.1f;

        barreDeVie.fillAmount = vieActuelle / vieMax;

        if (vieActuelle >= 80)
        {
            barreDeVie.color = barreComplet;
        }
        else if (vieActuelle >= 60)
        {
            barreDeVie.color = barre80;
        }
        else if (vieActuelle >= 40)
        {
            barreDeVie.color = barre60;
        }
        else if (vieActuelle >= 20)
        {
            barreDeVie.color = barre40;
        }
        else if (vieActuelle >= 5)
        {
            barreDeVie.color = barre20;
        }
        else if (vieActuelle <= 0)
        {
            //GAME OVER with scene
            SceneManager.LoadScene("GameOver");

        }

    }
}