using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void RecargarEscena() 
    {
        Destroy(GameObject.Find("CanvasHUD")); 
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("Player"));
        SceneManager.LoadScene("Scene1");
    }

    public void RecargarMenu()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
