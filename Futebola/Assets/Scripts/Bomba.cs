using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    [SerializeField]
    private GameObject BombFX;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisonEnter2D(Collision2D outro)
    {
        if(outro.gameObject.CompareTag("ball"))
        {
            Instantiate (BombFX, new Vector2 (this.transform.position.x,this.transform.position.y), Quaternion.identity);
        }
    }
}