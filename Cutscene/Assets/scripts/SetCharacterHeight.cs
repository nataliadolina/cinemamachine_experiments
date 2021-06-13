using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterHeight : MonoBehaviour
{
    private float startPosY;

    void Start()
    {
        startPosY = transform.position.y;
    }

    public void Execute()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, startPosY, pos.z);
    }
}
