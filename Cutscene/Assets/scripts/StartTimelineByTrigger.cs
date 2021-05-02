using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;

public enum TimelineEvent
{
    Play,
    Stop
}

public class StartTimelineByTrigger : MonoBehaviour
{
    [SerializeField] private TimelineEvent events;
    private PlayableDirector playableDirector;

    private Dictionary<TimelineEvent, Action> typesEvent = null;
    
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        typesEvent = new Dictionary<TimelineEvent, Action>()
        {
            { TimelineEvent.Play, playableDirector.Play},
            { TimelineEvent.Stop, playableDirector.Stop}
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print(events);
            typesEvent[events]();
        }
    }
}
