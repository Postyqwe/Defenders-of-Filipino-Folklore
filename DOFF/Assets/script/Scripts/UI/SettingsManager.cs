using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private const string QualityLevelKey = "QualityLevel";

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt(QualityLevelKey, qualityIndex);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        // Load the saved quality level from PlayerPrefs during initialization
        if (PlayerPrefs.HasKey(QualityLevelKey))
        {
            int savedQualityLevel = PlayerPrefs.GetInt(QualityLevelKey);
            QualitySettings.SetQualityLevel(savedQualityLevel);
        }
    }
}
