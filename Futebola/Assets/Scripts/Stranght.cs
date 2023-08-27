using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D Ball;
    private float force = 1000f;
    private RotationArrow rot; //defini uma variavel e coloquei o mesmo nome do arquivo de codigo da rotation para poder usar o angulo de rotacao que esta la dentro

    void Start()
    {
        Ball = GetComponent<Rigidbody2D> ();
        rot = GetComponent<RotationArrow> ();
    }

    // Update is called once per frame
    void Update()
    {
        apliForce ();
    }

    void apliForce()
    {
        float x = force * Mathf.Cos(rot.zRotate * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(rot.zRotate * Mathf.Deg2Rad);

       if(Input.GetKeyUp(KeyCode.Space))
        {
            Ball.AddForce (new Vector2 (x, y));
        }
    }
}
