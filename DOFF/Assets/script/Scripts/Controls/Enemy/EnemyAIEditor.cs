using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(EnemyAI))]
public class EnemyAIEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyAI enemyAI = (EnemyAI)target;

        // Draw the follow range as a wireframe sphere in the Scene view
        Handles.color = new Color(0f, 1f, 0f, 1f);
        Handles.DrawWireDisc(enemyAI.transform.position, Vector3.up, enemyAI.followRange);

        // Draw the attack range as a wireframe sphere in the Scene view
        Handles.color = new Color(1f, 0f, 0f, 1f);
        Handles.DrawWireDisc(enemyAI.transform.position, Vector3.up, enemyAI.attackRange);

        // Label for follow range
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.green;
        Handles.Label(enemyAI.transform.position + Vector3.up * enemyAI.followRange, "Follow Range", style);

        // Label for attack range
        style.normal.textColor = Color.red;
        Handles.Label(enemyAI.transform.position + Vector3.up * enemyAI.attackRange, "Attack Range", style);
    }
}
