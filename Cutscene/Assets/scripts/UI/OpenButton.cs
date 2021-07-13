using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenButton : MonoBehaviour
{
    private Button button;
    public Button _OpenButton { get { return button; } }

    public static Chest chestToOpen;
    //public Chest ChestToOpen { get { return chestToOpen; } set { chestToOpen = value;  } }

    void Awake()
    {
        button = GetComponent<Button>();
        SetbuttonActive(false);
    }

    public void Update()
    {
        if (chestToOpen != null)
        {
            SetbuttonActive(true);
        }

        else
        {
            SetbuttonActive(false);
        }
    }

    private void SetbuttonActive(bool value)
    {
        button.interactable = value;
        button.enabled = value;
    }

    public void ClickToOpen()
    {
        if (chestToOpen != null)
        {
            chestToOpen.Open();
        }
    }
}
