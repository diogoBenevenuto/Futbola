using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D Ball;
    public float force = 0;
    private RotationArrow rot; //defini uma variavel e coloquei o mesmo nome do arquivo de codigo da rotation para poder usar o angulo de rotacao que esta la dentro
    public Image seta2Img;

    void Start()
    {
        Ball = GetComponent<Rigidbody2D> ();
        rot = GetComponent<RotationArrow> ();
    }

    
    void Update()
    {
        ControlaForca ();
        apliForce ();
    }

    void apliForce()
    {
        float x = force * Mathf.Cos(rot.zRotate * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(rot.zRotate * Mathf.Deg2Rad);

       if(rot.liberaBola == true)
        {
            Ball.AddForce (new Vector2 (x, y));
            rot.liberaBola = false;
        }
    }

    void ControlaForca()
    {
        if(rot.liberaRot == true)
        {
            float moveX = Input.GetAxis ("Mouse X");

            if(moveX < 0)
            {
                seta2Img.fillAmount += 0.8f * Time.deltaTime;
                force = seta2Img.fillAmount * 1000;
            }
            if(moveX > 0)
            {
                seta2Img.fillAmount -= 0.8f * Time.deltaTime;
                force = seta2Img.fillAmount * 1000;
            }
        }
    }
}
