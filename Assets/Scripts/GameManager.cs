using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Obj
{
    public DragDrop objets;
    public string nom;
}

public class GameManager : MonoBehaviour
{
    public List<string> BDD = new List<string>();
    public List<Obj> JarBDD = new List<Obj>();
    public GameObject prefab;
    public Transform parentGO;
    public static GameManager instance;
    public DragDrop currentObject;
    public DragDrop lastObject;
    public List<GameObject> ButtonForDeco = new List<GameObject>();

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        for (int i = 0; i < ButtonForDeco.Count; i++)
        {
            ButtonForDeco[i].SetActive(false);
        }
    }
    void Update()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        if (Input.GetKeyDown(KeyCode.Delete))
            Destroy(currentObject.gameObject, 2);
        if (currentObject != null)
        {
            if (currentObject.Done)
            {
                Obj o = new Obj();
                o.objets = currentObject;
                o.nom = currentObject.nom;
                if (search(o) == -1)
                    JarBDD.Add(o);
            }
            if(currentObject.takeObject)
            {
                for (int i = 0; i < ButtonForDeco.Count; i++)
                {
                    ButtonForDeco[i].SetActive(true);
                }

            }
        }
        if (lastObject != null)
        {
            if (lastObject.Done)
            {
                Obj o = new Obj();
                o.objets = lastObject;
                o.nom = lastObject.nom;
                if (search(o) == -1)
                    JarBDD.Add(o);
            }
        }


    }
    public void SwitchObject(DragDrop dragDrop)
    {
        if(currentObject != null)
            lastObject = currentObject;
        currentObject = dragDrop;
        if (lastObject != null)
        {
            lastObject.takeObject = false;
            lastObject.Done = true;
        }
    }
    int search(Obj obj)
    {
        for (int i = 0; i < JarBDD.Count; i++)
        {
            if (JarBDD[i].objets == obj.objets)
                return i;
        }

        return -1;
    }



    public void DeleteAllChild()
    {
        for (var i = parentGO.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(parentGO.transform.GetChild(i).gameObject);
        }
    }
    public void ClearJarBDD()
    {
        JarBDD.Clear();

    }
    public void ClickValidate()
    {
        currentObject.Done = true;
        Obj o = new Obj();
        o.objets = currentObject;
        o.nom = currentObject.nom;
        

        if (search(o) == -1)
            JarBDD.Add(o);
        for (int i = 0; i < ButtonForDeco.Count; i++)
        {
            ButtonForDeco[i].SetActive(false);
        }
    }
    public void ClickDelete()
    {
        Obj o = new Obj();
        o.objets = currentObject;
        o.nom = currentObject.nom;
        int index = search(o);

        if (index != -1)
            JarBDD.RemoveAt(index);

        Destroy(currentObject.gameObject, 0.3f);
        for (int i = 0; i < ButtonForDeco.Count; i++)
        {
            ButtonForDeco[i].SetActive(false);
        }
    }

}
