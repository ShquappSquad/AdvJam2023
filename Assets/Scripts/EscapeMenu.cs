using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    public Canvas canvas;

    public void OpenEscape()
    {
        canvas.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0;
        //Debug.Log("Open Menu");

    }

    public void CloseEscape()
    {
        canvas.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        //Debug.Log("Close Menu");
        //isOpen = false;
    }

    public void GoToMainMenu()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
