using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaControll : MonoBehaviour
{
    //position arrow
    // arrow
    public GameObject arrowGO;
    //Angle
    public float zRotate;
    public bool liberaRot = false;
    public bool liberaBola = false;

    // Força
    private Rigidbody2D Ball;
    public float force = 0;
    public GameObject seta2Img;

    //Paredes
    private Transform paredeLD,paredeLE;

    public float velocidadeMinima = 0.01f;
    private bool chutou = false;

    //KillBall Anim
    [SerializeField]
    private GameObject KillBallAnim;
    void Awake()
    {
        arrowGO = GameObject.Find ("Arrow");
        seta2Img = arrowGO.transform.GetChild(0).gameObject;
        arrowGO.GetComponent<Image>().enabled = false;
        seta2Img.GetComponent<Image>().enabled = false;
        paredeLD = GameObject.Find("ParedeLD").GetComponent<Transform> ();
        paredeLE = GameObject.Find("ParedeLE").GetComponent<Transform> ();
    }
    void Start()
    {
       
        //Força
        Ball = GetComponent<Rigidbody2D> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        RotacaoArrow ();
        InputDeRotacao ();
        LimitaRotacao (); 
        PosicionaArrow();  

        //Força
        ControlaForca ();
        apliForce ();
        // Paredes
        Paredes();

        DestroiBolaParada();
        
        if (chutou && Ball.velocity.magnitude > velocidadeMinima)
        {
            liberaBola = false;
        }

    }

    void DestroiBolaParada()
    {
        
        if (chutou && Ball.velocity.magnitude <= velocidadeMinima && !GameManager.instance.win)
        {
            Instantiate(KillBallAnim, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.instance.bolasInScene -= 1;
            GameManager.instance.bolasNum -= 1;
        }
    }

    IEnumerator DelayChute()
    {
        
        yield return new WaitForSeconds(0.3f);
        chutou = true;
    }
        void PosicionaArrow()
    {
        arrowGO.GetComponent<Image>().rectTransform.position = transform.position;
    }
   

    void RotacaoArrow()
    {
        arrowGO.GetComponent<Image>().rectTransform.eulerAngles = new Vector3 (0,0,zRotate);
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
        if(GameManager.instance.tiro == 0)
        {
            liberaRot = true;
            arrowGO.GetComponent<Image>().enabled = true;
            seta2Img.GetComponent<Image>().enabled = true;
        }
        
    }

    void OnMouseUp()
    {
        liberaRot = false;
        arrowGO.GetComponent<Image>().enabled = false;
        seta2Img.GetComponent<Image>().enabled = false;
        if(GameManager.instance.tiro == 0 && force > 0)
        {
            liberaBola = true;
            seta2Img.GetComponent<Image>().fillAmount = 0;
            AudioManager.instance.SonsFXToca (1);
            GameManager.instance.tiro = 1;
        }
        
    }

     //Força
    void apliForce()
    {
        float x = force * Mathf.Cos(zRotate * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(zRotate * Mathf.Deg2Rad);

       if(liberaBola == true)
        {
            Ball.AddForce (new Vector2 (x, y));
            StartCoroutine(DelayChute());
            liberaBola = false;
        }
    }



    void ControlaForca()
    {
        if(liberaRot == true)
        {
            float moveX = Input.GetAxis ("Mouse X");

            if(moveX < 0)
            {
                seta2Img.GetComponent<Image>().fillAmount += 0.8f * Time.deltaTime;
                force = seta2Img.GetComponent<Image>().fillAmount * 1000;
            }
            if(moveX > 0)
            {
                seta2Img.GetComponent<Image>().fillAmount -= 0.8f * Time.deltaTime;
                force = seta2Img.GetComponent<Image>().fillAmount * 1000;
            }
        }
    }


    void BolaDinamica()
    {
        this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
    }

    void Paredes()
    {
        if(this.gameObject.transform.position.x > paredeLD.position.x)
        {
            Destroy(this.gameObject);
            GameManager.instance.bolasInScene -= 1;
            GameManager.instance.bolasNum -= 1;
        }
        if(this.gameObject.transform.position.x < paredeLE.position.x)
        {
            Destroy(this.gameObject);
            GameManager.instance.bolasInScene -= 1;
            GameManager.instance.bolasNum -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("morte") && !GameManager.instance.win)
        {
            Instantiate(KillBallAnim, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.instance.bolasInScene -= 1;
            GameManager.instance.bolasNum -= 1;

        }
        if(other.gameObject.CompareTag("win"))
        {
            GameManager.instance.win = true;
            int temp = OndeEstou.instance.fase +1;
            temp++;
            PlayerPrefs.SetInt("Level"+temp, 1);
        }
    }
}
