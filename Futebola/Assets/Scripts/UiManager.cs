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
        pontoUI = GameObject.Find("PontoUI").GetComponent<Text> ();
        bolasUI = GameObject.Find("bolasUI").GetComponent<Text> ();
        losePainel = GameObject.Find("LosePainel");
        winPainel = GameObject.Find("WinPainel");
        pausePainel = GameObject.Find("PausePainel");
        pauseBtn = GameObject.Find("pause").GetComponent<Button> ();
        pauseBtn_Return = GameObject.Find("BtnPlay").GetComponent <Button> ();

        LigaDesligaPainel();

        pauseBtn.onClick.AddListener (Pause);
        pauseBtn_Return.onClick.AddListener (PauseReturn);
    }
    
    public void UpdateUI()
    {
        pontoUI.text = ScoreManager.instance.moedas.ToString();
        bolasUI.text = GameManager.instance.bolasNum.ToString();
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
}
