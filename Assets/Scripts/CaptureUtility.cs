using UnityEngine;

/**
 * @brief An object that lets us control screenshot capture.
 */
public class CaptureUtility : MonoBehaviour
{
    /**
     * @method Obtain a unique filename for a new capture screenshot.
     * @params None
     * @returns A unique filename that can be used for a capture file.
     */
    public string GetUniqueCaptureName()
    {
        // Timestamp the captured file.
        System.DateTime now = System.DateTime.Now;
        string timestampString = now.ToString();
        timestampString = timestampString.Replace(':', '-');
        timestampString = timestampString.Replace('/', '-');
        return Application.persistentDataPath + "/Bingo-" + timestampString + ".png";
    }

    /**
     * @method Capture a screenshot from this app.
     * @param screenshotName - The name of the file to save.
     * @returns None; a screenshot file will be saved.
     */
    public void Capture(string screenshotName)
    {
        // Capture and log.
        ScreenCapture.CaptureScreenshot(screenshotName);
        Debug.Log("Captured file: " + screenshotName);
    }
}
