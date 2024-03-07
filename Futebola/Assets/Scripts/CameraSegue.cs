using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    [SerializeField]
    private Transform objE, objD, Ball;
    private float t = 1;

    
    void Update()
    {
        if(GameManager.instance.jogoComecou == true)
        {
            if(transform.position.x != objE.position.x)
            {
                t -= .04f * Time.deltaTime;
                transform.position = new Vector3(Mathf.SmoothStep(objE.position.x,Camera.main.transform.position.x,t),this.transform.position.y,this.transform.position.z);
            }

            if(Ball == null && GameManager.instance.bolasInScene > 0)
            {
                Ball = GameObject.Find("football(Clone)").GetComponent<Transform>();
            }
            else if(GameManager.instance.bolasInScene > 0)
            {
                Vector3 posCam = transform.position;
                posCam.x = Ball.position.x;
                posCam.x = Mathf.Clamp(posCam.x, objE.position.x, objD.position.x);
                transform.position = posCam;
            }
        }
    }
}
