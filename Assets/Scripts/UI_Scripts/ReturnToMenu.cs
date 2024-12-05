using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ReturnToMenu : MonoBehaviour
{
    public Button ReturnToMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        ReturnToMenuButton.onClick.AddListener(ReturnToMenuB);
    }

    void ReturnToMenuB()
    {
        SceneManager.LoadScene(1);
    }
}
