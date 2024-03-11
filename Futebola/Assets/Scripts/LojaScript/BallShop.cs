using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BallShop : MonoBehaviour
{
    public static BallShop instance;

    public List<Balls> ballsList = new List<Balls>();
    public List<GameObject> suportBallList = new List<GameObject>();
    public List<GameObject> buyBtnList = new List<GameObject>();

    public GameObject baseBallIntem;
    public Transform content;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        FillList();
    }

    
    void Update()
    {
        
    }

    void FillList()
    {
        foreach(Balls b in ballsList)
        {
            GameObject ballItens = Instantiate(baseBallIntem) as GameObject;
            ballItens.transform.SetParent(content, false);
            SuportBalls item = ballItens.GetComponent<SuportBalls>();

            item.ballID = b.ballsID;
            item.priceBall.text = b.priceBalls.ToString ();
            item.btnBuy.GetComponent<BuyBalls>().ballsIDe = b.ballsID;

            buyBtnList.Add(item.btnBuy);

            suportBallList.Add(ballItens);

            if(PlayerPrefs.GetInt("BTN"+item.ballID) == 1)
            {
                b.buyBalls = true;
            }

            if(b.buyBalls == true)
            {
                item.spriteBall.sprite = Resources.Load<Sprite>("Ball/" + b.NamespriteBalls);
                item.priceBall.text = "Comprado!";
            }
            else
            {
                item.spriteBall.sprite = Resources.Load<Sprite>("Ball/" + b.NamespriteBalls + "_Sale");
            }

        }
    }
    public void UpdateSprite(int ball_id)
    {
        for (int i = 0; i < suportBallList.Count; i++) 
        {
            SuportBalls suportBallsScript = suportBallList[i].GetComponent<SuportBalls>();

            if(suportBallsScript.ballID == ball_id)
            {
                for(int j = 0; j < ballsList.Count; j++)
                {
                    if (ballsList[j].ballsID == ball_id)
                    {
                        if (ballsList[j].buyBalls == true)
                        {
                            suportBallsScript.spriteBall.sprite = Resources.Load<Sprite>("Ball/" + ballsList[j].NamespriteBalls);
                            suportBallsScript.priceBall.text = "Comprado!";
                            SaveBallShopInfo(suportBallsScript.ballID);
                        }
                        else
                        {
                            suportBallsScript.spriteBall.sprite = Resources.Load<Sprite>("Ball/" + ballsList[j].NamespriteBalls + "_Sale");
                        }
                    }

                }
            }
        }
    }

    void SaveBallShopInfo(int idBall)
    {
        for(int i = 0; i < ballsList.Count; i++ )
        {
            SuportBalls ballSup = suportBallList[i].GetComponent<SuportBalls>();

            if(ballSup.ballID == idBall)
            {
                PlayerPrefs.SetInt("BTN" + ballSup.ballID,ballSup.btnBuy ? 1 : 0);
            }
        }
    }
}
