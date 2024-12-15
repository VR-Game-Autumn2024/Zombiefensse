using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemPointage : MonoBehaviour
{
    public static SystemPointage instance;

    public Text textScore;//Texte du score
    public Text textHighScore; //Texte score de fin

    int score = 0; //Score
    int highScore = 0; //ScoreFin

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        //Le score se réinitialise à 0 lorsqu'on commence la partie
        textScore.text = "Score: " + score.ToString();

        textHighScore.text = "HighScore: " + highScore.ToString();
    }

    public void AjouterPoint()
    {
        score += 1;
        textScore.text = "Score: " + score.ToString();
        if(highScore < score) {
            PlayerPrefs.SetInt("highScore", score);
        }
        PlayerPrefs.Save();
    }
}
