using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopMenuUI : MonoBehaviour
{
    public GameObject ObjectToDrag;
    
    bool IsLock = true;
    public Image ImageLock;
    public TextMeshProUGUI TextCost;
    //public int Cost;
    public int LevelToUnlock;

    void Start()
    {
        //TextCost.text = "" + Cost;
    }

    void Update()
    {
        if (MainGame.Instance.IntCurrentAnimal >= LevelToUnlock-1)
            IsLock = false;


        if (!IsLock)
            ImageLock.enabled = false;
        else
            ImageLock.enabled = true;
    }
}
