using UnityEngine;
using System.Collections;

public class PlayerSpawnPositionScript : MonoBehaviour
{

    /// <summary>
    /// Game object to which to restore position & rotation.
    /// </summary>
    public GameObject StartingPositionGameObject = null;

    // Use this for initialization
    void Start()
    {
        SetPosition();
    }

    /// <summary>
    /// Sets player position & rotation to starting position object's
    /// </summary>
    void SetPosition()
    {
        Debug.Assert(StartingPositionGameObject != null, "Starting position object not set for player object {0}", gameObject);

        if (StartingPositionGameObject != null)
        {
            gameObject.transform.position = StartingPositionGameObject.transform.position;
            gameObject.transform.rotation = StartingPositionGameObject.transform.rotation;
        }
    }

}
