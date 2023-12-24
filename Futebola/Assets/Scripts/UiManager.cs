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
    private GameObject losePainel, winPainel;

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
        LigaDesligaPainel();
    }

    void MostraMoeda(Scene cena, LoadSceneMode modo)
    {
        pontoUI = GameObject.Find("PontoUI").GetComponent<Text> ();
        bolasUI = GameObject.Find("bolasUI").GetComponent<Text> ();
        losePainel = GameObject.Find("LosePainel");
        winPainel = GameObject.Find("WinPainel");
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
    IEnumerator tempo()
    {
        yield return new WaitForSeconds (0.001f);
        losePainel.SetActive(false);
        winPainel.SetActive(false);
    }
}
