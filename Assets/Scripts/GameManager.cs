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
    public List<GameObject> Abri = new List<GameObject>();
    public List<GameObject> Nourriture = new List<GameObject>();
    public List<GameObject> Decoration = new List<GameObject>();
    public List<GameObject> Plante = new List<GameObject>();
    public static GameManager instance;
    public DragDrop currentObject;
    public DragDrop lastObject;
    public Text planteText;
    public Text abriText;
    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        if (Input.GetKeyDown(KeyCode.Delete))
            Destroy(currentObject.gameObject, 2);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(prefab, new Vector3(2, 10, 2), Quaternion.identity);
            go.GetComponent<DragDrop>().nom = BDD[UnityEngine.Random.Range(0, BDD.Count)];
            go.GetComponent<DragDrop>().type = (Type)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Type)).Length);
            Material mat = go.GetComponent<Renderer>().material;
            if (go.GetComponent<DragDrop>().type == Type.abri)
                mat.color = Color.black;
            if (go.GetComponent<DragDrop>().type == Type.nourriture)
                mat.color = Color.red;
            if (go.GetComponent<DragDrop>().type == Type.decoration)
                mat.color = Color.blue;
            if (go.GetComponent<DragDrop>().type == Type.plante)
                mat.color = Color.green;
        }

        if (lastObject != null)
        {
            if (currentObject.Done)
            {
                if (currentObject.type == Type.abri && !Abri.Contains(currentObject.gameObject))
                    Abri.Add(currentObject.gameObject);
                if (currentObject.type == Type.nourriture && !Nourriture.Contains(currentObject.gameObject))
                    Nourriture.Add(currentObject.gameObject);
                if (currentObject.type == Type.decoration && !Decoration.Contains(currentObject.gameObject))
                    Decoration.Add(currentObject.gameObject);
                if (currentObject.type == Type.plante && !Plante.Contains(currentObject.gameObject))
                    Plante.Add(currentObject.gameObject);


                Obj o = new Obj();
                o.objets = currentObject;
                o.nom = currentObject.nom;
                if (!search(o))
                    JarBDD.Add(o);

            }
            if (lastObject.Done)
            {
                if (lastObject.type == Type.abri && !Abri.Contains(lastObject.gameObject))
                    Abri.Add(lastObject.gameObject);
                if (lastObject.type == Type.nourriture && !Nourriture.Contains(lastObject.gameObject))
                    Nourriture.Add(lastObject.gameObject);
                if (lastObject.type == Type.decoration && !Decoration.Contains(lastObject.gameObject))
                    Decoration.Add(lastObject.gameObject);
                if (lastObject.type == Type.plante && !Plante.Contains(lastObject.gameObject))
                    Plante.Add(lastObject.gameObject);

                Obj o = new Obj();
                o.objets = lastObject;
                o.nom = lastObject.nom;
                if (!search(o))
                    JarBDD.Add(o);
            }
        }

        planteText.text = Plante.Count.ToString();
        abriText.text = Abri.Count.ToString();
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
}
