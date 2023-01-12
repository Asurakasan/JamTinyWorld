using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OpenMenuUI : MonoBehaviour
{
    public static OpenMenuUI Instance;
    private void Awake()
    {
        Instance = this; 
    }
    public bool IsMenuOpen;
    public GameObject Menu;

    public void OnClickOpenMenuToLeft()
    {
        if (IsMenuOpen)
        {
            Menu.transform.DOComplete();
            Menu.transform.DOLocalMoveX(-666, 1).OnComplete(CloseMenu);
        }
        else
        {
            Menu.transform.DOComplete();
            Menu.transform.DOLocalMoveX(0, 1).OnComplete(OpenMenu);
        }
    }
    public void OnClickOpenMenuToRight()
    {
        if (IsMenuOpen)
        {
            Menu.transform.DOComplete();
            Menu.transform.DOLocalMoveX(450, 1).OnComplete(CloseMenu);
        }
        else
        {
            Menu.transform.DOComplete();
            Menu.transform.DOLocalMoveX(0, 1).OnComplete(OpenMenu);
        }
    }
    public void OnClickOpenMenuToDown()
    {
        if (IsMenuOpen)
        {
            Menu.transform.DOComplete();
            Menu.transform.DOLocalMoveY(-450, 1).OnComplete(CloseMenu);
        }
        else
        {
            Menu.transform.DOComplete();
            Menu.transform.DOLocalMoveY(0, 1).OnComplete(OpenMenu);
        }
    }
    void CloseMenu()
    {
        IsMenuOpen = false;
    }

    void OpenMenu()
    {
        IsMenuOpen = true;
    }
}
