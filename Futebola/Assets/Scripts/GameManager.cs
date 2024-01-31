using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Bola 
    [SerializeField]
    private GameObject bola;
    public int bolasNum = 2;
    private bool bolaMorreu ;
    public int bolasInScene = 0;
    public Transform pos;
    public bool win;
    public int tiro = 0;
    //public int ondeEstou;
    public bool jogoComecou;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad (this.gameObject);
        }
        else
        {
            Destroy (gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        if(OndeEstou.instance.fase != 4)
        {
            pos = GameObject.Find("InitialPosition").GetComponent<Transform>();
            //ondeEstou = SceneManager.GetActiveScene().buildIndex;
            StartGame();
        }
        
    }
    void Start()
    {
        ScoreManager.instance.GameStartScoreM ();
    }

    
    void Update()
    {
        ScoreManager.instance.UpdateScore ();
        UiManager.instance.UpdateUI();
        NascBolas ();
        if(bolasNum <= 0)
        {
            GameOver();
        }
        if(win == true)
        {
            WinGame();
        }
    }

    void NascBolas()
    {
        if(bolasNum > 0 && bolasInScene == 0 )
        {
            Instantiate (bola,new Vector2(pos.position.x,pos.position.y),Quaternion.identity);
            bolasInScene += 1;
            tiro = 0;
        }
    }

    void GameOver()
    {
        UiManager.instance.GameOverUI();
        jogoComecou = false;
    }
    void WinGame()
    {
        UiManager.instance.WinGameUI();
        jogoComecou = false;
    }

    void StartGame()
    {
        jogoComecou = true;
        bolasNum = 2;
        bolasInScene = 0;
        win = false;
        UiManager.instance.StartUI();
        
    }
}
