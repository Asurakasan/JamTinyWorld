using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXshop : MonoBehaviour
{
    public GameObject ActiveThis;
    public List<GameObject> ActiveFalse = new List<GameObject>();
    private void Start()
    {
        ActiveThis.SetActive(false);
        for (int i = 0; i < ActiveFalse.Count; i++)
        {
            ActiveFalse[i].SetActive(false);
        }
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
}
