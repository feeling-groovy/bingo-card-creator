using UnityEngine;
using UnityEditor;

/**
 * @brief Editor inspector script for bingo cards
 */
[CustomEditor(typeof(BingoCard))]
public class BingoCardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BingoCard card = target as BingoCard;
        int validContentCount = card.ValidContentCount;
        if (validContentCount < 24)
        {
            EditorGUILayout.LabelField(validContentCount.ToString() + " / 24 Pieces of Valid Content Entered");
        }
        else
        {
            if (GUILayout.Button("Load Into UI"))
            {
                LoadBingoCardIntoUI(card);
            }
        }

        GUILayout.Space(20);
        base.OnInspectorGUI();
    }

    /**
     * @method Cause a bingo card's information to be copied into our singleton UI
     * @param card - The card whose information we wish to copy.
     * @returns None; the information held in the bingo card UI will be overwritten with the contents of this card.
     */
    private void LoadBingoCardIntoUI(BingoCard card)
    {
        // Find our UI object.
        BingoCardUI ui = FindObjectOfType<BingoCardUI>();
        if (ui != null)
        {
            // If we found it, load this card into the UI.
            ui.LoadBingoCard(card);
            EditorUtility.SetDirty(ui);
        }
    }
}
