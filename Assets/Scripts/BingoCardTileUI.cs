using UnityEngine;
using UnityEngine.UI;

/**
 * @brief Control script for a single bingo card tile.
 */
public class BingoCardTileUI : MonoBehaviour
{
    // Is this the free space?
    public bool IsFreeSpace = false;

    // Our UI widgets
    public Image Background;
    public Image Interior;
    public Text ContentText;
}
