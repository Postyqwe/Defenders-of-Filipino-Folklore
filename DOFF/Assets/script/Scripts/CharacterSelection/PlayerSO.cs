using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters")]
public class PlayerSO : ScriptableObject
{
    public int ID;

    public string characterName;
    public int hp;
    public int atk;

    public Sprite sprite;
}
