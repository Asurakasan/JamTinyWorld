using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : MonoBehaviour
{
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        water = GetComponentInChildren<Water>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
