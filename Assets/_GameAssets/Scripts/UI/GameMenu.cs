using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // TODO Tal vez hay que destruir el sound manager también.
    string[] objectsToDestroy = { "CanvasHUD", "GameManager", "Player" };
    public void ReloadScene() 
    {
        DestroyObjects();
        SceneManager.LoadScene("Scene1");
    }

    public void ReloadMenu()
    {
        DestroyObjects();
        SceneManager.LoadScene("IntroScene");
    }

    private void DestroyObjects() 
    {
        foreach (string objectToDestroy in objectsToDestroy) 
        {
            GameObject objectTD = GameObject.Find(objectToDestroy);
            Destroy(objectTD);
        }
    }
}
