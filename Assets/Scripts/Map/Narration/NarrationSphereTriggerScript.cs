using UnityEngine;
using System.Collections;

public class NarrationSphereTriggerScript : MonoBehaviour
{
    /// <summary>
    /// Narration script which will be notified.
    /// </summary>
    public NarrationScript NarrationScript = null;

    // Use this for initialization
    void Start()
    {
        Debug.Assert(NarrationScript != null, "Narration script object not set for trigger object.");
    }

    void OnTriggerEnter(Collider other)
    {
        // if collided with narration object
        if (other.gameObject.tag == "TagNarrationObject")
        {
            // notify narrator
            NarrationTriggerObjectScript obj = other.gameObject.GetComponent<NarrationTriggerObjectScript>();
            if (obj != null)
            {
                NarrationScript.EnteredNarrationObject(obj);
            }
        }
    }
}
