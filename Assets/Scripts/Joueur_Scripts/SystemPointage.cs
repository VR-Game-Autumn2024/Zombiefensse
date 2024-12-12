using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemPointage : MonoBehaviour
{
    public static SystemPointage instance;

    public Text textScore;//Texte du score

    int score = 0; //Score

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Le score se réinitialise à 0 lorsqu'on commence la partie
        textScore.text = "Score: " + score.ToString();
    }

    public void AjouterPoint()
    {
        score += 1;
        textScore.text = "Score: " + score.ToString();
    }
}
