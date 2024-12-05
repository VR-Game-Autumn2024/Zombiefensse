using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UI_Start : MonoBehaviour
{
    public Button buttonStart;
    // Start is called before the first frame update
    void Start()
    {
        buttonStart.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
