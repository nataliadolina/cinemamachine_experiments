using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnableOrDisable
{
    Enable,
    Disable
}

public class SetActive : MonoBehaviour
{
    [SerializeField] private EnableOrDisable enableOrDisable;
    private Dictionary<EnableOrDisable, bool> typesEvent = null;
    private void Start()
    {
        Debug.Log("Started");
    }
    public void Execute()
    {
        //typesEvent = new Dictionary<EnableOrDisable, bool>()
        //{
        //    { EnableOrDisable.Enable, true },
        //    { EnableOrDisable.Disable, false },
        //};
        gameObject.SetActive(true);
    }

 
}
