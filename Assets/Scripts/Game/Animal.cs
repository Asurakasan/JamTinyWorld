using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Animal
{
    public string Name;
    public Sprite Sprite;
    public GameObject Jar;
    public bool Water;
    public List<GameObject> AnimalsVisual;
    [TextArea] public string Description;
    public List<Task> Tasks;
}
