using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public enum Test { a,b,c}


public class MainGame : MonoBehaviour
{
    //public List<Test> test;
    public GameObject PrefabTask;
    public List<Animal> Animals;
    public int Money = 0;
    public Animal CurrentAnimal;
    private RequirementsUI _requirementsUI;
    private DescriptionUI _descriptionUI;
    private int _currentAnimal = 0;
    public static MainGame Instance;
    public int IntCurrentAnimal { get => _currentAnimal; }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _requirementsUI = GetComponent<RequirementsUI>();
        _descriptionUI = GetComponent<DescriptionUI>();
        CurrentAnimal = Animals[_currentAnimal];
        _requirementsUI.SwitchRequirement();
        _descriptionUI.SwitchContentDescription();
    }

    // Update is called once per frame
    void Update()
    {
        _requirementsUI.UITaskEnded();
        CountObjectBDD();
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
