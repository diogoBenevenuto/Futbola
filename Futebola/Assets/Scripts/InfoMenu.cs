using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoMenu : MonoBehaviour
{
    private Animator info;
    private AudioSource music;
    public Sprite soundL, soundD;
    private Button btnSound;

    void Start()
    {
        info = GameObject.FindGameObjectWithTag("menuInfo").GetComponent<Animator>() as Animator;
        music = GameObject.Find("AudioManager").GetComponent<AudioSource>() as AudioSource;
        btnSound = GameObject.Find("BtnSom").GetComponent<Button> () as Button;
    }

    public void AnimaInfoPositive()
    {
        info.Play("AnimaInfo");
    }

    public void AnimaInfoNegative()
    {
        info.Play("AnimaInfoInverse");
    }

    public void MuteMusic()
    {
        music.mute = !music.mute;

        if(music.mute == true)
        {
            btnSound.image.sprite = soundD;
        }
        else
        {
            btnSound.image.sprite = soundL;
        }
    }

    public void Linkedin()
    {
        Application.OpenURL("www.linkedin.com/in/diogo-benevenuto-da-silva-monteiro-b504451ab/");
    }
}
