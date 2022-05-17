using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    Text goldTxt;
    public static int goldAmount;
    void Start()
    {
        goldAmount = PlayerPrefs.GetInt("GoldText", goldAmount);
        goldTxt = GetComponent<Text>();
    }

    void Update()
    {
        goldTxt.text = goldAmount.ToString();
        PlayerPrefs.SetInt("GoldText", goldAmount);
        PlayerPrefs.Save();
    }
}
