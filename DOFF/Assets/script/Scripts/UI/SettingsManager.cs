using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle englishToggle;
    public Toggle tagalogToggle;
    private const string QualityLevelKey = "QualityLevel";

    private void Start()
    {
        if (PlayerPrefs.HasKey(QualityLevelKey))
        {
            int savedQualityLevel = PlayerPrefs.GetInt(QualityLevelKey);
            QualitySettings.SetQualityLevel(savedQualityLevel);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("Language"))
        {
            string language = PlayerPrefs.GetString("Language");
            if (language == "English")
            {
                englishToggle.isOn = true;
                tagalogToggle.isOn = false;
            }
            else if (language == "Tagalog")
            {
                englishToggle.isOn = false;
                tagalogToggle.isOn = true;
            }
        }
        else
        {
            PlayerPrefs.SetString("Language", "English");
            PlayerPrefs.Save();
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt(QualityLevelKey, qualityIndex);
        PlayerPrefs.Save();
    }
    public void SetLanguageToEnglish()
    {
        PlayerPrefs.SetString("Language", "English");
        PlayerPrefs.Save();
    }

    public void SetLanguageToTagalog()
    {
        PlayerPrefs.SetString("Language", "Tagalog");
        PlayerPrefs.Save();
    }
}
