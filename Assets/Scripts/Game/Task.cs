using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[Serializable]
public class Task
{
    public string Name;
    public int Number;
    public int MoneyByTask;
    public string Description;
    public bool TaskEnded = false;
}
