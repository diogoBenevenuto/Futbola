using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBalls : MonoBehaviour
{
    public int ballsIDe;
    public Text btnText;

    public void BuyBallBtn()
    {
        for(int i = 0; i < BallShop.instance.ballsList.Count; i++)
        {
            if (BallShop.instance.ballsList[i].ballsID == ballsIDe && !BallShop.instance.ballsList[i].buyBalls)
            {
                BallShop.instance.ballsList[i].buyBalls = true;
                UpdadteBuyBtn();
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
                if (BallShop.instance.ballsList[j].ballsID == buyBallScript.ballsIDe && BallShop.instance.ballsList[j].buyBalls && BallShop.instance.ballsList[j].ballsID != ballsIDe)
                {
                    buyBallScript.btnText.text = "Use";
                }

            }
        }
    }
}
