using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class MainGame : MonoBehaviour
{
    public Text moneyText;
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
        moneyText.text = Money.ToString();
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
        if (CurrentAnimal != null)
        {
            for (var i = ParentJar.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(ParentJar.transform.GetChild(i).gameObject);
            }
        }
            GameObject go = Instantiate(CurrentAnimal.Jar, ParentJar);

        var pos = transform.position;
        

        for (int x = 0; x < CurrentAnimal.AnimalsVisual.Count; x++)
        {
            Instantiate(CurrentAnimal.AnimalsVisual[x], ParentJar);
            CurrentAnimal.AnimalsVisual[x].transform.position = go.GetComponent<Jar>().SpawnPoint[Random.Range(0, go.GetComponent<Jar>().SpawnPoint.Count)].position;
        }
        WaterOrNot(go);
        GameManager.instance.InstantiateVFX(go);
        GameManager.instance.InstantiateTemps(go);
    }
    public void WaterOrNot(GameObject animal)
    {
        if (CurrentAnimal.Water)
        {
            animal.GetComponent<Jar>().water.SetActive(true);
        }
        else if(!CurrentAnimal.Water)
            animal.GetComponent<Jar>().water.SetActive(false);

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
                if (tempCount >= CurrentAnimal.Tasks[j].Number)
                {
                    CurrentAnimal.Tasks[j].TaskEnded = true;
                }
            }
        }
    }
}
