﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private GameObject endPanel;
    public static bool hasKey = false;
    [SerializeField]
    private GameObject panelMenu;
    private static int score = 0;
    public enum State { Playing, Paused, GameOver }
    private static State state = State.Playing;
    [SerializeField]
    private Text textPause;
    [SerializeField]
    private GameObject textScore;

    private static GameManager _instance;

    private void Awake()
    {
        state = State.Playing;
        // Patron singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (textPause == null) {
            // Capturamos las referencias de las variables
            textPause = GameObject.Find("TextPause").GetComponent<Text>();
            panelMenu = GameObject.Find("PanelMenu");
            panelMenu.SetActive(false);
        }
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (state == State.Playing)
            {
                PauseGame();
            }
            else if (state == State.Paused)
            {
                UnpauseGame();
            }
        }
    }

    public void DoGameOver()
    {
        /*
         *  - Paramos todo
         *  - Mostramos Game Over
         *  - Menu (Restar | Menu | load)
        */

        // Cambiamos el estado
        state = State.GameOver;
        // Poner time scale en 0 y desactivar scripts del player
        StopGame();
        // Activar el menú
        panelMenu.SetActive(true);
        // Desbloqueamos el cursor del ratón
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndPanel()
    {
        /*
         *  - Paramos todo
         *  - Mostramos Game Over
         *  - Menu (Restar | Menu | load)
        */

        // Cambiamos el estado
        state = State.GameOver;
        // Poner time scale en 0 y desactivar scripts del player
        StopGame();
        // Activar el menú EndPanel
        endPanel.SetActive(true);
        // Desbloqueamos el cursor del ratón
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public static void LoadMyScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public static void LoadScene(string nombreEscena) 
    {
        SceneManager.LoadScene(nombreEscena);
    }

    
    private void PauseGame()
    {
        state = State.Paused;
        StopGame();
        textPause.enabled = true;
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<PlayerManager>().enabled = false;
    }
    private void UnpauseGame()
    {
        state = State.Playing;
        Time.timeScale = 1;
        player.GetComponent<PlayerManager>().enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        textPause.enabled = false;
    }

    public void UpdateScore(int puntos)
    {
        score = score + puntos;
        textScore.GetComponent<Text>().text = score.ToString();
        player.GetComponent<PlayerManager>().score = score;
    }    
}
