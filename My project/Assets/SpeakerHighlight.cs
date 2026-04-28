using UnityEngine;
using UnityEngine.UI;

public class SpeakerHighlight : MonoBehaviour
{
    public Image guardImage;  
    public Image playerImage;

    public void FocusSpeaker(string speakerName)
    {
        Color shadowColor = new Color(0.4f, 0.4f, 0.4f, 1f); 
        
        if (guardImage != null) guardImage.color = shadowColor;
        if (playerImage != null) playerImage.color = shadowColor;

        if (speakerName.Contains("Guard") && guardImage != null)
        {
            guardImage.color = Color.white;
        }
        else if (speakerName.Contains("System") && playerImage != null)
        {
            playerImage.color = Color.white;
        }
    }
}