using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectSaveLevel
{
    None,
    Lvl1,
    Lvl2,
    Lvl3,
    Lvl4,
    Lvl5,
    Lvl6,
    Lvl7,
}
public class SaveLevel : MonoBehaviour,IDataPersistence
{
    [SerializeField]
    private SelectSaveLevel selectedLevel;

    private void Start()
    {
        DataPersistenceManager.instance.SaveGame();
    }
    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(GameData data)
    {
        switch (selectedLevel)
        {
            case SelectSaveLevel.None:
                break; 
            case SelectSaveLevel.Lvl1:
                data.lvl1 = true;
                break;
            case SelectSaveLevel.Lvl2:
                data.lvl2 = true;
                break;
            case SelectSaveLevel.Lvl3:
                data.lvl3 = true;
                break;
            case SelectSaveLevel.Lvl4:
                data.lvl4 = true;
                break;
            case SelectSaveLevel.Lvl5:
                data.lvl5 = true;
                break;

            case SelectSaveLevel.Lvl6:
                data.lvl6 = true;
                break;
            case SelectSaveLevel.Lvl7:
                data.lvl7 = true;
                break;
        }
    }
}
