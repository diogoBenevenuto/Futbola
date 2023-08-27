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

    void Start()
    {
        PosicionaArrow();
        PosicionaBola();
    }

    // Update is called once per frame
    void Update()
    {
        rotacaoArrow ();
        InputDeRotacao ();
    }

    void PosicionaArrow()
    {
        arrowImg.rectTransform.position = startPoss.position;
    }
    void PosicionaBola()
    {
        this.gameObject.transform.position = startPoss.position;
    }

    void rotacaoArrow()
    {
        arrowImg.rectTransform.eulerAngles = new Vector3 (0,0,zRotate);
    }

    void InputDeRotacao()
    {
     if(Input.GetKey(KeyCode.UpArrow))
     {
        zRotate += 1.5f;
     }
     if(Input.GetKey(KeyCode.DownArrow))
     {
        zRotate -= 1.5f;
     }
    }
}
