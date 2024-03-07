using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManagerLevels : MonoBehaviour
{
    [SerializeField]
    private Text moedasLevel;
    void Start()
    {
        moedasLevel.text = PlayerPrefs.GetInt("moedasSave").ToString();
    }

}
