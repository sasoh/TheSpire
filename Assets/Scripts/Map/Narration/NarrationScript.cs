using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class NarrationScript : MonoBehaviour
{
    /// <summary>
    /// Text object to which to print narration text to.
    /// </summary>
    public Text NarrationTextObject = null;

    /// <summary>
    /// Sphere trigger in player's object to detect narration transitions.
    /// </summary>
    public SphereCollider PlayerSphereTrigger = null;

    HashSet<string> pastNarrationObjectsSet = null;

    bool shouldDisappear = false;
    float disappearanceCounter = 0.0f;

    // Use this for initialization
    void Start()
    {
        Debug.Assert(NarrationTextObject != null, "No narration text obejct set, no text will be shown.");
        Debug.Assert(PlayerSphereTrigger != null, "No player trigger sphere collider set. Narration progress won't work.");

        pastNarrationObjectsSet = new HashSet<string>();
        shouldDisappear = false;

        NarrationTextObject.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldDisappear == true)
        {
            disappearanceCounter -= Time.deltaTime;
            if (disappearanceCounter <= 0.0f)
            {
                // clear text, reset timer
                shouldDisappear = false;

                NarrationTextObject.text = "";
            }
        }
    }

    public void EnteredNarrationObject(NarrationTriggerObjectScript narrationObject)
    {
        if (pastNarrationObjectsSet.Contains(narrationObject.Identifier) == false)
        {
            pastNarrationObjectsSet.Add(narrationObject.Identifier);

            // set text
            NarrationTextObject.text = narrationObject.NarrationMessage;

            // disappear?
            disappearanceCounter = narrationObject.NarrationMessage.Length * narrationObject.DisappearanceTimeoutPerLetter;
            Debug.Log(string.Format("Text will take {0} seconds to disappear.", disappearanceCounter));
            shouldDisappear = true;
        }
    }

}
