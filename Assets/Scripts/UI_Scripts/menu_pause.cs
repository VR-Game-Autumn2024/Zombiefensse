using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_pause : MonoBehaviour
{
    public OVRInput.Button b_button;
    public OVRInput.Button a_button;
    public GameObject menuPause;
    public Button pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(UnPauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.Get(OVRInput.Button.Two) || Input.GetKeyDown("space")))
        {
            menuPause.SetActive(true);
            Time.timeScale = 0f;
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            menuPause.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    void UnPauseGame()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
    }


}
