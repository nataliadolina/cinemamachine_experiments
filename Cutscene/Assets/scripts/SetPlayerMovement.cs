using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnableOrDisable
{
    Enable,
    Disable
}

public class SetPlayerMovement : MonoBehaviour
{
    [SerializeField] private EnableOrDisable switchTo;
    private Dictionary<EnableOrDisable, bool> typesEvent = null;

    private PlayerMove moveScript;

    void Start()
    {
        moveScript = GetComponent<PlayerMove>();
        typesEvent = new Dictionary<EnableOrDisable, bool>()
        {
            { EnableOrDisable.Enable, true },
            { EnableOrDisable.Disable, false },
        };
    }

    public void Execute()
    {
        moveScript.enabled = typesEvent[switchTo];
    }
}
