using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FloreReactionTimeline : MonoBehaviour
{
    private PlayableDirector playableDirector = null;

    private void OnEnable()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playableDirector.Play();
        }
    }
}
