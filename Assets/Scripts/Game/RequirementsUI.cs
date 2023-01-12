
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RequirementsUI : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public Image Visu;

    public Transform ParentPrefab;
    public List<GameObject> Tasks;
    void Start()
    {
        Name.text = MainGame.Instance.CurrentAnimal.Name;
        Visu.sprite = MainGame.Instance.CurrentAnimal.Sprite;
    }

    void Update()
    {
    }

    public void UITaskEnded()
    {
        for (int i = 0; i < MainGame.Instance.CurrentAnimal.Tasks.Count; i++)
        {
            if (Tasks[i].GetComponent<TaskUi>().ID == i)
            {
                Tasks[i].GetComponent<TaskUi>().ValidatedTask.SetActive(MainGame.Instance.CurrentAnimal.Tasks[i].TaskEnded);
            }
        }
    }

    public void CheckTaskEnded()
    {
        var task = MainGame.Instance.CurrentAnimal.Tasks;
        int taskValidatedMoney = 0;
        for (int i = 0; i < task.Count; i++)
        {
            if (task[i].TaskEnded)
                taskValidatedMoney += task[i].MoneyByTask;
        }
        MainGame.Instance.Money += taskValidatedMoney;
    }

    public void SwitchRequirement()
    {
        for (var i = ParentPrefab.transform.childCount - 1; i > 0; i--)
        {
            Object.Destroy(ParentPrefab.transform.GetChild(i).gameObject);
        }
        Name.text = MainGame.Instance.CurrentAnimal.Name;
        Visu.sprite = MainGame.Instance.CurrentAnimal.Sprite;
        int idItem = 0;
        foreach (var item in MainGame.Instance.CurrentAnimal.Tasks)
        {
            GameObject go = Instantiate(MainGame.Instance.PrefabTask, ParentPrefab);
            go.GetComponent<TaskUi>().Content.text = item.Description;
            go.GetComponent<TaskUi>().ID = idItem;
            /*go.transform.parent = 
                GetComponentInChildren<>*/
            Tasks.Add(go);
            idItem++;
        }
    }
}
