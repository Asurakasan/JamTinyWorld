using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MainGame : MonoBehaviour
{
    public Transform ParentJar;
    public GameObject PrefabTask;
    public List<Animal> Animals;
    public int Money = 0;
    public Animal CurrentAnimal;
    private RequirementsUI _requirementsUI;
    private DescriptionUI _descriptionUI;
    private int _currentAnimal = 0;
    public bool Pause = false;
    public static MainGame Instance;
    public int IntCurrentAnimal { get => _currentAnimal; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _requirementsUI = GetComponent<RequirementsUI>();
        _descriptionUI = GetComponent<DescriptionUI>();
        CurrentAnimal = Animals[_currentAnimal];
        _requirementsUI.SwitchRequirement();
        _descriptionUI.SwitchContentDescription();
        PopObject();
    }

    void Update()
    {
        _requirementsUI.UITaskEnded();
        CountObjectBDD();
        if (Pause)
        {
            Time.timeScale = 0;
        }
        else if (!Pause)
        {
            Time.timeScale = 1;
        }
    }
    public void ClickNext()
    {
        _requirementsUI.Tasks.Clear();
        _requirementsUI.CheckTaskEnded();
        if (_currentAnimal + 1 < Animals.Count)
            _currentAnimal++;
        CurrentAnimal = Animals[_currentAnimal];
        GameManager.instance.DeleteAllChild();
        GameManager.instance.ClearJarBDD();
        _requirementsUI.SwitchRequirement();
        _descriptionUI.SwitchContentDescription();
        PopObject();
    }

    public void PopObject()
    {
        GameObject go = Instantiate(CurrentAnimal.Jar, ParentJar);

        var pos = transform.position;

        //foreach (var item in CurrentAnimal.AnimalsVisual)
        //{
        //    Instantiate(item, transform);
        //    pos.x += 2;
        //    transform.transform.position = pos;
        //}
        for (int x = 0; x < CurrentAnimal.AnimalsVisual.Count; x++)
        {
            Instantiate(CurrentAnimal.AnimalsVisual[x], ParentJar);
            pos.x += 2 * x;
            CurrentAnimal.AnimalsVisual[x].transform.position = pos;
        }
    }

    void CountObjectBDD()
    {
        int tempCount = 0;

        for (int j = 0; j < CurrentAnimal.Tasks.Count; j++)
        {
            tempCount = 0;
            for (int i = 0; i < GameManager.instance.JarBDD.Count; i++)
            {
                if (GameManager.instance.JarBDD[i].nom == CurrentAnimal.Tasks[j].Name)
                    tempCount++;
                print(tempCount);
                if (tempCount >= CurrentAnimal.Tasks[j].Number)
                {
                    CurrentAnimal.Tasks[j].TaskEnded = true;
                }
            }
        }
    }
}
