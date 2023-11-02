using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{
    public AchievementSO ASO;
    AchievementManager achievementManager;

    private Button button;
    private void Start()
    {
        achievementManager = FindAnyObjectByType<AchievementManager>();
        button = GetComponent<Button>();

    }

    public void OnButtonClick(int index)
    {
        if(ASO != null)
        {
            achievementManager.AchievementDisplay(ASO.achievementName, ASO.achievementIcon, ASO.achievementDescription, index);
        }
        else
        {
            Debug.Log("No Scriptabble Object");
        }
    }
}
