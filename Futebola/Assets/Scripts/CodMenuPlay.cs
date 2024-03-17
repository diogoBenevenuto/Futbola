using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodMenuPlay : MonoBehaviour
{
    private Animator barraAnim;
    private bool back;
    public void Play()
    {
        SceneManager.LoadScene(4);
    }
    
    public void AnimMenu()
    {
        barraAnim = GameObject.FindGameObjectWithTag("barraAnimTag").GetComponent<Animator>();
        if(back == false)
        {
            barraAnim.Play("Move_UI");
            back = true;
        }
        else
        {
            barraAnim.Play("Move_UI_Inverse");
            back = false;
        }
       
    }
}
