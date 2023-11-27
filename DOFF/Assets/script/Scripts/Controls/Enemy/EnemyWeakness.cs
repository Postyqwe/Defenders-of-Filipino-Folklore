using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyWeaknessType
{
    Tikbalang,
    Mananangal,
    Tyanak,
    Mangkukulam,
    WhiteLady,
    Kapre
}

public class EnemyWeakness : MonoBehaviour
{
    public List<EnemyWeaknessType> weaknesses;

    // Check if the enemy has a specific weakness
    public bool HasWeakness(List<WeaponStrength> strengths)
    {
        foreach (var strength in strengths)
        {
            if (weaknesses.Contains((EnemyWeaknessType)strength))
            {
                return true;
            }
        }
        return false;
    }
}
