using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public Text pontoUI;

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
    }
    
    public void UpdateUI()
    {
        pontoUI.text = ScoreManager.instance.moedas.ToString();
    }
}
