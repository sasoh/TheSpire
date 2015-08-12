using UnityEngine;
using System.Collections;

public class NarrationTriggerObjectScript : MonoBehaviour
{
    /// <summary>
    ///  Unique identifier for narration object.
    /// </summary>
    string identifier;
    public string Identifier
    {
        get
        {
            return identifier;
        }

    }

    /// <summary>
    ///  Message that will be shown.
    /// </summary>
    public string NarrationMessage = "";
    
    /// <summary>
    /// Timeout for disappearance per letter.
    /// </summary>
    public float DisappearanceTimeoutPerLetter = 0.1f;

    // Use this for initialization
    void Start()
    {
        // generate unique identifier
        identifier = System.Guid.NewGuid().ToString();
    }

    void OnTriggerEnter(Collider other)
    {


    }
}
