
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
    //public List<GameObject> Tasks;
    void Start()
    {
        Name.text = MainGame.Instance.CurrentAnimal.Name;
        Visu.sprite = MainGame.Instance.CurrentAnimal.Sprite;
    }

    void Update()
    {

    }

    public void SwitchRequirement()
    {
        for (var i = ParentPrefab.transform.childCount - 1; i > 0; i--)
        {
            Object.Destroy(ParentPrefab.transform.GetChild(i).gameObject);
        }
        Name.text = MainGame.Instance.CurrentAnimal.Name;
        Visu.sprite = MainGame.Instance.CurrentAnimal.Sprite;
        foreach (var item in MainGame.Instance.CurrentAnimal.Tasks)
        {
            Instantiate(MainGame.Instance.PrefabTask, ParentPrefab);
        }
    }
}
