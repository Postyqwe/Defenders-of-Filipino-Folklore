using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement")]
public class AchievementSO : ScriptableObject
{
    public int achievementID;
    public string achievementName;
    public string achievementDescription;
    public Sprite achievementIcon;
}
