using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int moedas;

    void Awake() // Para garantir de não ter duplicatas, e também que o Objeto n morra com a passagem das fazes
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
    }
    
    public void GameStartScoreM()
    {
        if(PlayerPrefs.HasKey("moedasSave"))
        {
            moedas = PlayerPrefs.GetInt("moedasSave");
        }
        else
        {
            moedas = 100;
            PlayerPrefs.SetInt("moedasSave", moedas);
        }
    }
    public void UpdateScore()
    {
        moedas = PlayerPrefs.GetInt ("moedasSave");
    }

    public void ColetaMoedas(int coin)
    {
        moedas += coin;
        SalvaMoedas(moedas);
    }

    public void PerdeMoedas(int coin)
    {
        moedas -= coin;
        SalvaMoedas(moedas);
    }

    public void SalvaMoedas(int coin)
    {
        PlayerPrefs.SetInt("moedasSave", coin);
    }
}
