using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void RecargarEscena() 
    {
        SceneManager.LoadScene("Scene1");
    }

    public void RecargarMenu()
    { 
        SceneManager.LoadScene("IntroScene");
    }
}
