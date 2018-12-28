using UnityEditor;
using UnityEngine;

/**
 * @brief Exposes editor controls that allow screenshots to be captured.
 */
[CustomEditor(typeof(CaptureUtility))]
public class CaptureUtilityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (Application.isPlaying)
        {
            if (GUILayout.Button("Capture"))
            {
                CaptureUtility utility = target as CaptureUtility;
                utility.Capture(utility.GetUniqueCaptureName());
            }
        }
        else
        {
            GUILayout.Label("Run application to capture screenshots.");
        }
    }
}
