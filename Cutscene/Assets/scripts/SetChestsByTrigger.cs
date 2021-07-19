using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChestsByTrigger : MonoBehaviour
{
    private ChestsController cc=null;

    private void Awake()
    {
        cc = FindObjectOfType<ChestsController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            cc.SetChestsActive();
            Destroy(gameObject);
        }
    }
}
