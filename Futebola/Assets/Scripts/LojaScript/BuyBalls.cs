using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBalls : MonoBehaviour
{
    public int ballsIDe;
    public Text btnText;
    private GameObject txtCoin;
    private Animator falid;

    public void BuyBallBtn()
    {
        for(int i = 0; i < BallShop.instance.ballsList.Count; i++)
        {
            if (BallShop.instance.ballsList[i].ballsID == ballsIDe && !BallShop.instance.ballsList[i].buyBalls && PlayerPrefs.GetInt("moedasSave") >= BallShop.instance.ballsList[i].priceBalls)
            {
                BallShop.instance.ballsList[i].buyBalls = true;
                UpdadteBuyBtn();
                ScoreManager.instance.PerdeMoedas(BallShop.instance.ballsList[i].priceBalls);
                GameObject.Find("pontosStore").GetComponent<Text>().text = PlayerPrefs.GetInt("moedasSave").ToString();
            }
            else if(BallShop.instance.ballsList[i].ballsID == ballsIDe && !BallShop.instance.ballsList[i].buyBalls && PlayerPrefs.GetInt("moedasSave") <= BallShop.instance.ballsList[i].priceBalls)
            {
                falid = GameObject.FindGameObjectWithTag("falid").GetComponent<Animator>();
                falid.Play("WithoutMoneyAnim");
            }
            else if (BallShop.instance.ballsList[i].ballsID == ballsIDe && BallShop.instance.ballsList[i].buyBalls)
            {
                UpdadteBuyBtn();
            }
        }

        BallShop.instance.UpdateSprite(ballsIDe);
    }

    void UpdadteBuyBtn()
    {
        btnText.text = "Using";

        for(int i = 0; i < BallShop.instance.buyBtnList.Count; i++)
        {
            BuyBalls buyBallScript = BallShop.instance.buyBtnList[i].GetComponent<BuyBalls>();

            for (int j = 0; j < BallShop.instance.ballsList.Count; j++)
            {
                if (BallShop.instance.ballsList[j].ballsID == buyBallScript.ballsIDe)
                {
                    BallShop.instance.SaveBallShopText(buyBallScript.ballsIDe, "Using");

                    if(BallShop.instance.ballsList[j].ballsID == buyBallScript.ballsIDe && BallShop.instance.ballsList[j].buyBalls && BallShop.instance.ballsList[j].ballsID == ballsIDe)
                    {
                        OndeEstou.instance.ballInUse = buyBallScript.ballsIDe;
                        PlayerPrefs.SetInt("ballUse",buyBallScript.ballsIDe);
                    }
                }

                if (BallShop.instance.ballsList[j].ballsID == buyBallScript.ballsIDe && BallShop.instance.ballsList[j].buyBalls && BallShop.instance.ballsList[j].ballsID != ballsIDe)
                {
                    buyBallScript.btnText.text = "Use";

                    BallShop.instance.SaveBallShopText(buyBallScript.ballsIDe, "Use");
                }

            }
        }
    }

    public void falidInvers()
    {
        falid = GameObject.FindGameObjectWithTag("falid").GetComponent<Animator>();
        falid.Play("WithoutMoneyAnimInverse");
    }
}
