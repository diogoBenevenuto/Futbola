using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationArrow : MonoBehaviour
{
    //position arrow
    [SerializeField]private Transform startPoss;
    // arrow
    [SerializeField]private Image arrowImg;
    //Angle
    public float zRotate;
    public bool liberaRot = false;
    public bool liberaBola = false;

    void Start()
    {
        PosicionaArrow();
        PosicionaBola();
    }


    void Update()
    {
        RotacaoArrow ();
        InputDeRotacao ();
        LimitaRotacao (); 
    }

    void PosicionaArrow()
    {
        arrowImg.rectTransform.position = startPoss.position;
    }
    void PosicionaBola()
    {
        this.gameObject.transform.position = startPoss.position;
    }

    void RotacaoArrow()
    {
        arrowImg.rectTransform.eulerAngles = new Vector3 (0,0,zRotate);
    }

    void InputDeRotacao()
    {
 
        if(liberaRot == true)
        {
    
            float moveY = Input.GetAxis ("Mouse Y");

            if(zRotate < 90)
            {
                if(moveY > 0)
                {
                    zRotate += 1.5f;
                }
            }

            if(zRotate > 0)
            {
                if(moveY < 0)
                {
                    zRotate -= 1.5f;
                }
            }

        }
    }

    void LimitaRotacao()
    {
        if(zRotate >= 90 )
        {
            zRotate = 90;
        }
        if(zRotate <= 0)
        {
            zRotate = 0;
        }
    }

    void OnMouseDown()
    {
        liberaRot = true;
    }

    void OnMouseUp()
    {
        liberaRot = false;
        liberaBola = true;
    }
}
