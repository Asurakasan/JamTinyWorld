using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public enum Test { a,b,c}


public class MainGame : MonoBehaviour
{
    //public List<Test> test;
    public GameObject PrefabTask;
    public List<Animal> Animals;
    public Animal CurrentAnimal;
    private RequirementsUI _requirementsUI;
    private DescriptionUI _descriptionUI;
    private int _currentAnimal = 0;
    public static MainGame Instance;
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
        
    }
    public void ClickNext()
    {
        if(_currentAnimal+1 < Animals.Count)
        _currentAnimal++;
        CurrentAnimal = Animals[_currentAnimal];
        _requirementsUI.SwitchRequirement();
        _descriptionUI.SwitchContentDescription();
    }
}
