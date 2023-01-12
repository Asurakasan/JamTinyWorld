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

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        if (Input.GetKeyDown(KeyCode.Delete))
            Destroy(currentObject.gameObject, 2);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(prefab, new Vector3(2, 10, 2), Quaternion.identity, parentGO);
            go.GetComponent<DragDrop>().nom = BDD[UnityEngine.Random.Range(0, BDD.Count)];
            go.GetComponent<DragDrop>().type = (Type)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Type)).Length);

        }

        if (lastObject != null)
        {
            if (currentObject.Done)
            {
                Obj o = new Obj();
                o.objets = currentObject;
                o.nom = currentObject.nom;
                if (!search(o))
                    JarBDD.Add(o);
            }
            if (lastObject.Done)
            {
                Obj o = new Obj();
                o.objets = lastObject;
                o.nom = lastObject.nom;
                if (!search(o))
                    JarBDD.Add(o);
            }
        }


    }
    public void SwitchObject(DragDrop dragDrop)
    {
        lastObject = currentObject;
        currentObject = dragDrop;
        if (lastObject != null)
        {
            lastObject.takeObject = false;
            lastObject.Done = true;
        }
    }
    bool search(Obj obj)
    {
        for (int i = 0; i < JarBDD.Count; i++)
        {
            if (JarBDD[i].objets == obj.objets)
                return true;
        }

        return false;
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
}
