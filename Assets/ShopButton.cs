using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public ShopMenuUI selfUI;
    public OpenMenuUI Shop;
    
    // Start is called before the first frame update
    void Start()
    {
        selfUI = GetComponent<ShopMenuUI>();
        Shop = GetComponentInParent<OpenMenuUI>();
    }

    public void OnClickInstantiate()
    {
        if(!selfUI.IsLock)
        {

        GameObject go = Instantiate(selfUI.ObjectToDrag, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, GameManager.instance.parentGO);
        go.GetComponent<DragDrop>().takeObject = true;
        GameManager.instance.SwitchObject(go.GetComponent<DragDrop>());
        Shop.OnClickOpenMenuToLeft();
        }
    }
}
