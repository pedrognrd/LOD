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
    public enum Estado { Jugando, Pausado, GameOver }
    private static Estado estado = Estado.Jugando;

    private int puntuacion = 0;
    public int Puntuacion { get => puntuacion; set => puntuacion = value; }

    [SerializeField]
    private Text textPause;
    [SerializeField]
    private Text textoGameOver;
    [SerializeField]
    private GameObject panelMenu;

    // Al ser public y static, podemos acceder desde cualquier sitio
    public static bool hasKey = false;

    private static GameManager _instance;

    private void Awake()
    {
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
        DontDestroyOnLoad(this.gameObject);
        player = GameObject.Find("Player");
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (textPause == null)
        {
            // Capturamos las referencias de las variablesa
            textPause = GameObject.Find("TextPause").GetComponent<Text>();
            textoGameOver = GameObject.Find("TextGameOver").GetComponent<Text>();
            panelMenu = GameObject.Find("PanelMenu");
            panelMenu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (estado == Estado.Jugando)
            {
                Pausarjuego();
            }
            else if (estado == Estado.Pausado)
            {
                Despausarjuego();
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
        estado = Estado.GameOver;
        // Poner time scale en 0 y desactivar scripts del player
        DetenerJuego();
        // Mostrar texto game over
        textoGameOver.enabled = true;
        // Activar el menú
        panelMenu.SetActive(true);
        // Desbloqueamos el cursor del ratón
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void DetenerJuego()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerManager>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;
    }

    private void Pausarjuego()
    {
        estado = Estado.Pausado;
        DetenerJuego();
        textPause.enabled = true;
        IncrementarPuntuacion(100);
    }


    private void Despausarjuego()
    {
        estado = Estado.Jugando;
        Time.timeScale = 1;
        player.GetComponent<PlayerManager>().enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;
        textPause.enabled = false;
    }

    public void IncrementarPuntuacion(int puntos)
    {
        puntuacion = puntuacion + puntos;
        textScore.GetComponent<Text>().text = puntuacion.ToString();
    }
}
