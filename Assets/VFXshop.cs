using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXshop : MonoBehaviour
{
    public GameObject ActiveThis;
    private Jar ScriptJar;
    public List<GameObject> ActiveFalse = new List<GameObject>();
    public int index;
    private void Start()
    {
        
    }
    // Start is called before the first frame update
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
        for (int i = 0; i < ScriptJar.Meteo.Count; i++)
        {
            if (i == index)
                ActiveThis = ScriptJar.Meteo[i];
            else
                ActiveFalse.Add(ScriptJar.Meteo[i]);
        }
        ActiveThis.SetActive(false);
        for (int i = 0; i < ActiveFalse.Count; i++)
        {
            ActiveFalse[i].SetActive(false);
        }
    }
}
