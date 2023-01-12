using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public ShopMenuUI selfUI;
    // Start is called before the first frame update
    void Start()
    {
        selfUI = GetComponent<ShopMenuUI>();
    }

    public void OnClickInstantiate()
    {
        GameObject go = Instantiate(selfUI.ObjectToDrag, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        go.GetComponent<DragDrop>().takeObject = true;
        GameManager.instance.SwitchObject(go.GetComponent<DragDrop>());
        OpenMenuUI.Instance.OnClickOpenMenuToLeft();
    }
}
