using UnityEngine;
using UnityEditor;

/**
 * @brief Provides access to additional controls for the bingo card UI
 */
[CustomEditor(typeof(BingoCardUI))]
public class BingoCardUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(20);
        if (GUILayout.Button("Refresh Tiles"))
        {
            (target as BingoCardUI).Refresh();
        }
    }
}
