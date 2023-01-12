using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DescriptionUI : MonoBehaviour
{
    public TextMeshProUGUI Content;
    // Start is called before the first frame update
    void Start()
    {
        Content.text = MainGame.Instance.CurrentAnimal.Description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchContentDescription()
    {
        Content.text = MainGame.Instance.CurrentAnimal.Description;
    }


}
