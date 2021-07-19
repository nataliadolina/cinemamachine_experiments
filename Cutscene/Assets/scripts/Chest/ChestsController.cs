using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestsController : MonoBehaviour
{
    private Chest[] chests;
    public static Chest chestToOpen;

    void Start()
    {
        Debug.Log("Enabled chests");
        chests = FindObjectsOfType<Chest>();
        SetChestsActive();
    }

    public void SetChestsActive()
    {
        foreach (var chest in chests)
        {
            chest.gameObject.SetActive(!chest.gameObject.activeSelf);
            
            if (chest.gameObject.activeSelf)
            {
                chest.playerAppearParticles();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (chestToOpen != null)
                chestToOpen.Open();
        }
    }
}
