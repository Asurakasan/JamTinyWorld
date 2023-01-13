using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeureShop : MonoBehaviour
{
    public GameObject ActiveThis;
    private Jar ScriptJar;
    public List<GameObject> ActiveFalse = new List<GameObject>();
    public int index;
    private void Start()
    {
        
    }
    public void OnClickSwitch()
    {
        ActiveThis.SetActive(true);
        for (int i = 0; i < ActiveFalse.Count; i++)
        {
            ActiveFalse[i].SetActive(false);
        }
    }
    public void Instantiate(GameObject currentJar)
    {
        ActiveThis = null;
        ActiveFalse.Clear();
        ScriptJar = currentJar.GetComponent<Jar>();
        for (int i = 0; i < ScriptJar.Heure.Count; i++)
        {
            if (i == index)
                ActiveThis = ScriptJar.Heure[i];
            else
                ActiveFalse.Add(ScriptJar.Heure[i]);
        }
        ActiveThis.SetActive(false);
        for (int i = 0; i < ActiveFalse.Count; i++)
        {
            if(index != 0)
                ActiveFalse[i].SetActive(false);
        }
    }
}
