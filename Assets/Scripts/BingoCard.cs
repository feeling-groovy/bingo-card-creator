using UnityEngine;
using System.Collections.Generic;

/**
 * @brief Contains the contents for a single bingo card
 */
public class BingoCard : MonoBehaviour
{
    // Our card's title
    public string Title;

    // Custom free space text
    public Content CustomFreeSpaceContent;

    // Our bingo card content strings.
    public Content[] TileContent;

    // What color will we use for the screen's background?
    public Color ScreenBackgroundColor;

    // What color will we use for the card's background?
    public Color CardBackgroundColor;

    // What color will we use for the tile background?
    public Color TileBackgroundColor;

    // What color will we use for the card's content tile lining?
    public Color ContentLiningColor;

    // What color will we use for the content interior?
    public Color ContentInteriorColor;

    // What color will we use for the free space lining?
    public Color FreeSpaceLiningColor;

    // What color will we use for the free space's interior?
    public Color FreeSpaceInteriorColor;

    // What color will we use for the title text?
    public Color TitleTextColor;

    // What color will we use for the content text?
    public Color ContentTextColor;

    // What color will we use for free space's text?
    public Color FreeSpaceTextColor;

    // What font will we use for the title?
    public Font TitleFont;

    // What font will we use for the content?
    public Font ContentFont;

    // What font will we use for the free space?
    public Font FreeSpaceFont;

    /**
     * @brief Indicates the kind of content held in a bingo card tile.
     */
    public enum ContentType
    {
        // No content
        None,
        // Text content
        Text
    }

    /**
     * @brief Serializable content associated with a single bingo card tile.
     */
    [System.Serializable]
    public class Content
    {
        // Our string content
        public string Text = "";

        // Our type of content
        public ContentType Type = ContentType.Text;

        /**
         * @constructor
         */
        public Content()
        {
            Type = ContentType.Text;
            Text = "";
        }

        /**
         * @clone constructor
         * @param other - The item to clone.
         */
        public Content(Content other)
        {
            Type = other.Type;
            Text = other.Text;
        }
        
        /**
         * @property Is this bingo car content valid?
         * @returns true if this content is valid and can be used and false otherwise.
         */
        public bool IsValid
        {
            get
            {
                return Type == ContentType.Text && Text != "";
            }
        }
    }

    /**
     * @property Counts the number of valid pieces of content in this object.
     * @returns the number of valid pieces of content in this object.
     */
    public int ValidContentCount
    {
        get
        {
            return GetValidContent().Count;
        }
    }

    /**
     * @method Obtain a list of only the valid pieces of content held in this object.
     * @params None
     * @returns A list of only the valid content held in this object.
     */
    public List<Content> GetValidContent()
    {
        List<Content> validContent = new List<Content>();

        // Iterate over all of our content and find only the usable pieces.
        foreach (Content content in TileContent)
        {
            if (content.IsValid)
            {
                validContent.Add(content);
            }
        }

        return validContent;
    }
}
