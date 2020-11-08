using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject textScore;
    //public enum Estado { Jugando, EnInventario, EnMenu, GameOver, Finalizacion }
    public enum State { Playing, Paused, GameOver }
    private static State state = State.Playing;

    private int score = 0;
    public int Scxore { get => score; set => score = value; }

    [SerializeField]
    private Text textPause;
    [SerializeField]
    private GameObject panelMenu;

    // Al ser public y static, podemos acceder desde cualquier sitio
    public static bool hasKey = false;

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

    public static void CargarEscena(string nombreEscena) 
    {
        SceneManager.LoadScene(nombreEscena);
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
    }
}
