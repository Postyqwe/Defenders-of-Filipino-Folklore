using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    None,
    Minion,
    Boss,
    Location
}
[CreateAssetMenu(fileName = "New Beastiary", menuName = "Beastiary")]
public class BeastiarySO : ScriptableObject
{
    public Type type;
    public string beastName;
    public string beastDescription;
    public Sprite beastImage;
}
