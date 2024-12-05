using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloseGame : MonoBehaviour
{
    public Button Quitter;
    // Start is called before the first frame update
    void Start()
    {
        Quitter.onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
