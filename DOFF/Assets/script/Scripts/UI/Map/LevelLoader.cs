using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour,IDataPersistence
{
    [Header("Buttons")]
    public Button buttonlvl1;
    public Button buttonlvl2;
    public Button buttonlvl3;
    public Button buttonlvl4;
    public Button buttonlvl5;
    public Button buttonlvl6;
    public Button buttonlvl7;

    [Header("Debugging")]
    public bool lvl1;
    public bool lvl2;
    public bool lvl3;
    public bool lvl4;
    public bool lvl5;
    public bool lvl6;
    public bool lvl7;

    void Update()
    {
        SetButtonState(buttonlvl1, lvl1);
        SetButtonState(buttonlvl2, lvl2);
        SetButtonState(buttonlvl3, lvl3);
        SetButtonState(buttonlvl4, lvl4);
        SetButtonState(buttonlvl5, lvl5);
        SetButtonState(buttonlvl6, lvl6);
        SetButtonState(buttonlvl7, lvl7);
    }

    private void SetButtonState(Button button, bool isEnabled)
    {
        button.interactable = isEnabled;

        // Find the child named "Lock" and disable it
        Transform lockChild = button.transform.Find("Lock");
        if (lockChild != null)
        {
            lockChild.gameObject.SetActive(!isEnabled);
        }
    }

    public void LoadData(GameData data)
    {
        lvl1 = data.lvl1;
        lvl2 = data.lvl2;
        lvl3 = data.lvl3;
        lvl4 = data.lvl4;
        lvl5 = data.lvl5;
        lvl6 = data.lvl6;
        lvl7 = data.lvl7;
    }

    public void SaveData(GameData data)
    {
    }
}
