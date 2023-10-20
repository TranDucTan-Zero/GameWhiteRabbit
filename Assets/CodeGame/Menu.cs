using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
    public void yes()
    {
        SceneManager.LoadScene("Huongdan");
    }
    public void no()
    {
        SceneManager.LoadScene("SelcetLevel");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}