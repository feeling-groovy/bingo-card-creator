using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

/**
 * @brief The UI control script for bingo cards.
 */
public class BingoCardUI : MonoBehaviour
{
    // Our UI widgets.
    public Image ScreenBackground;
    public Image CardBackground;
    public Image TileBackground;
    public Text TitleText;

    /**
     * @brief A class used to set randomized tile content
     */
    public class RandomizedTileContent : BingoCard.Content, IComparable<RandomizedTileContent>
    {
        // Sort order.
        public int SortOrder;

        /**
         * @constructor
         * @param content - The content to clone this item from
         */
        public RandomizedTileContent(BingoCard.Content content) : base(content)
        {
            SortOrder = UnityEngine.Random.Range(0, 1000);
        }

        public int CompareTo(RandomizedTileContent other)
        {
            return SortOrder.CompareTo(other.SortOrder);
        }
    }

    /**
     * @method Cause a bingo card's information to be copied intothis UI
     * @param card - The card whose information we wish to copy.
     * @returns None; the information held in the bingo card UI will be overwritten with the contents of this card.
     */
    public void LoadBingoCard(BingoCard card)
    {
        // Set colors.
        ScreenBackground.color = card.ScreenBackgroundColor;
        CardBackground.color = card.CardBackgroundColor;
        TileBackground.color = card.TileBackgroundColor;
        TitleText.text = card.Title;
        TitleText.color = card.TitleTextColor;
        if (card.TitleFont != null)
        {
            TitleText.font = card.TitleFont;
        }

        // Obtain all tiles.
        BingoCardTileUI[] tiles = TileBackground.gameObject.GetComponentsInChildren<BingoCardTileUI>();

        // Obtain all usable content and create a sorted list of content to place into the card.
        List<BingoCard.Content> validContent = card.GetValidContent();
        List<RandomizedTileContent> randomizedContent = new List<RandomizedTileContent>();
        foreach (BingoCard.Content content in validContent)
        {
            randomizedContent.Add(new RandomizedTileContent(content));
        }

        // Sort our content.
        randomizedContent.Sort();

        // Place content into all of our tiles.
        int count = 0;
        foreach (BingoCardTileUI tile in tiles)
        {
            // Is this tile the free space?
            if (tile.IsFreeSpace)
            {
                tile.Background.color = card.FreeSpaceLiningColor;
                tile.Interior.color = card.FreeSpaceInteriorColor;
                tile.ContentText.color = card.FreeSpaceTextColor;
                if (card.FreeSpaceFont != null)
                {
                    tile.ContentText.font = card.FreeSpaceFont;
                }
                if (card.CustomFreeSpaceContent.IsValid)
                {
                    tile.ContentText.text = card.CustomFreeSpaceContent.Text;
                }
                else
                {
                    tile.ContentText.text = "FREE SPACE";
                }
            }
            else
            {
                tile.Background.color = card.ContentLiningColor;
                tile.Interior.color = card.ContentInteriorColor;
                tile.ContentText.color = card.ContentTextColor;
                if (card.ContentFont != null)
                {
                    tile.ContentText.font = card.ContentFont;
                }
                tile.ContentText.text = randomizedContent[count].Text;
                ++count;
            }
        }
    }

    /**
     * @method Refresh this UI, causing it to rebuild.
     * @params None
     * @returns None; the widgets in this object will be recreated.
     */
    public void Refresh()
    {
        // Obtain all of our tiles.
        BingoCardTileUI[] tiles = TileBackground.GetComponentsInChildren<BingoCardTileUI>();

        // Delete all but the first.
        BingoCardTileUI prefab = tiles[0];
        for (int i = 1; i < tiles.Length; ++i)
        {
            DestroyImmediate(tiles[i].gameObject);
        }

        // Finally, recreate copies of all of the tiles.
        for (int i = 1; i < 25; ++i)
        {
            GameObject tile = Instantiate(prefab.gameObject, TileBackground.rectTransform);

            // Is this the free space?
            if (i == 12)
            {
                tile.name = "Tile 2-2 Free Space";

                tile.GetComponent<BingoCardTileUI>().IsFreeSpace = true;
            }
            else
            {
                // Set this tile's name.
                tile.name = "Tile " + (i / 5).ToString() + "-" + (i % 5).ToString();
            }
        }
    }
}
