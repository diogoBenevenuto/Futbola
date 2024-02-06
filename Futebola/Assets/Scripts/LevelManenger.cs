using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManenger : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public string levelText;
        public bool habilitado;
        public int desbloqueado;
        public bool txtAtivo;

    }

    // Variaveis
    public GameObject button;
    public Transform localBtn;
    public List<Level> levelList;
    
    // Metodos para percorrer a lista e criar botões dos locais necessarios

        void ListaAdd()
        {
            foreach(Level level in levelList)
            {
                GameObject btnNovo = Instantiate(button) as GameObject;

                ButtonLevel btnNew = btnNovo.GetComponent<ButtonLevel> ();

                btnNew.levelTxtBTN.text = level.levelText;

                if(PlayerPrefs.GetInt("Level"+btnNew.levelTxtBTN.text) == 1)
                {
                    level.desbloqueado = 1;
                    level.habilitado = true;
                    level.txtAtivo = true;
                }

                btnNew.desbloquadoBTN = level.desbloqueado;

                btnNew.GetComponent<Button>().interactable = level.habilitado;

                btnNew.GetComponentInChildren<Text>().enabled = level.txtAtivo;

                btnNew.GetComponent<Button>().onClick.AddListener(() => ClickLevel("Level"+btnNew.levelTxtBTN.text));

                btnNovo.transform.SetParent(localBtn, false);
            }
        }

        void ClickLevel(string level)
        {
            SceneManager.LoadScene (level);
        }

    void Awake ()
    {
        Destroy(GameObject.Find("UiManager(Clone)"));
        Destroy(GameObject.Find("GameManager(Clone)"));
    }


    void Start()
    {
       // PlayerPrefs.DeleteAll();
        ListaAdd();
    }

    
    void Update()
    {
        
    }
}
