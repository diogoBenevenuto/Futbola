using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    private Text pontoUI, bolasUI;
    [SerializeField]
    private GameObject losePainel, winPainel, pausePainel;
    [SerializeField]
    private Button pauseBtn, pauseBtn_Return;
    [SerializeField]
    private Button btnNovamenteLose, btnMenuLose; //btn Lose

    private Button btnMenuWin, btnNovamenteWin, btnAvancaWin; //btn Win

    public int moedasNumAntes, moedasNumDepois, resultado;

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

        SceneManager.sceneLoaded += MostraMoeda;
        
    }

    void MostraMoeda(Scene cena, LoadSceneMode modo)
    {
        if (OndeEstou.instance.fase != 4)
        {
            //elementos da UI
            pontoUI = GameObject.Find("PontoUI").GetComponent<Text>();
            bolasUI = GameObject.Find("bolasUI").GetComponent<Text>();
            //Paineis
            losePainel = GameObject.Find("LosePainel");
            winPainel = GameObject.Find("WinPainel");
            pausePainel = GameObject.Find("PausePainel");
            // btn pause
            pauseBtn = GameObject.Find("pause").GetComponent<Button>();
            pauseBtn_Return = GameObject.Find("BtnPlay").GetComponent<Button>();
            //btn lose
            btnNovamenteLose = GameObject.Find("BtnNovamenteLOSE").GetComponent<Button>();
            btnMenuLose = GameObject.Find("BtnFazesLOSE").GetComponent<Button>();
            // btn win
            btnMenuWin = GameObject.Find ("BtnMenuWIN").GetComponent<Button>();
            btnNovamenteWin = GameObject.Find("BtnNovamenteWIN").GetComponent<Button>();
            btnAvancaWin = GameObject.Find("BtnAvancarWIN").GetComponent<Button>();

            //eventos

            //eventos pause
            pauseBtn.onClick.AddListener(Pause);
            pauseBtn_Return.onClick.AddListener(PauseReturn);

            //eventos you lose
            btnNovamenteLose.onClick.AddListener(JogarNovamente);
            btnMenuLose.onClick.AddListener(Levels);

            // eventos you win
            btnMenuWin.onClick.AddListener(Levels);
            btnNovamenteWin.onClick.AddListener(JogarNovamente);
            btnAvancaWin.onClick.AddListener(ProximaFase);
            moedasNumAntes = PlayerPrefs.GetInt("moedasSave");
        }
    }
    
    public void StartUI()
    {
        LigaDesligaPainel();
    }
    public void UpdateUI()
    {
        pontoUI.text = ScoreManager.instance.moedas.ToString();
        bolasUI.text = GameManager.instance.bolasNum.ToString();
        moedasNumDepois = ScoreManager.instance.moedas;
    }

    public void GameOverUI()
    {
        losePainel.SetActive(true);
    }

    public void WinGameUI()
    {
        winPainel.SetActive(true);
    }

    void LigaDesligaPainel()
    {
        StartCoroutine(tempo());
    }

    void Pause()
    {
        pausePainel.SetActive(true);
        pausePainel.GetComponent<Animator> ().Play ("MoveUI_Pause");
        Time.timeScale = 0;
    }

    void PauseReturn()
    {
        pausePainel.GetComponent<Animator>().Play("MoveUI_PauseR");
        Time.timeScale = 1;
        StartCoroutine(EsperaPause());
    }

    IEnumerator EsperaPause()
    {
        yield return new  WaitForSeconds (0.8f);
        pausePainel.SetActive (false);
    }

    IEnumerator tempo()
    {
        yield return new WaitForSeconds (0.001f);
        losePainel.SetActive(false);
        winPainel.SetActive(false);
        pausePainel.SetActive(false);
    }

    void JogarNovamente()
    {
        if (GameManager.instance.win == false)
        {
            SceneManager.LoadScene (OndeEstou.instance.fase);
            resultado = moedasNumDepois - moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            resultado = 0;
        }
        else
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
            resultado = 0;
        }
    }

    void Levels()
    {
        if(GameManager.instance.win == false)
        {
            resultado = moedasNumDepois - moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            resultado = 0;
            SceneManager.LoadScene(4);
        }
        else
        {
            resultado = 0;
            SceneManager.LoadScene(4);
        }
    }

    void ProximaFase()
    {
        if(GameManager.instance.win == true)
        {
            int temp = OndeEstou.instance.fase + 1;
            SceneManager.LoadScene(temp);
        }
    }
}
