using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;
using UnityEngine.Events;

public enum TimelineEvent
{
    Play,
    Stop
}

public class SetTimelineProcessByTrigger : Predicator
{

    [SerializeField] private TimelineEvent timelineEvent;
    public UnityEvent stuffToExecute;

    private PlayableDirector playableDirector = null;

    private Dictionary<TimelineEvent, Action> typesEvent = null;

    void Awake()
    {
        if (stuffToExecute == null)
            stuffToExecute = new UnityEvent();
    }

    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        typesEvent = new Dictionary<TimelineEvent, Action>()
        {
            { TimelineEvent.Play, playableDirector.Play},
            { TimelineEvent.Stop, playableDirector.Stop}
        };

        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        isTargetObject = IsTargetObject();
        if (isTargetObject(other))
        {
            Debug.Log(other.tag);
            typesEvent[timelineEvent]();
            stuffToExecute.Invoke();
        }
    }
}
