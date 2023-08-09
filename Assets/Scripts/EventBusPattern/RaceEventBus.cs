using System.Collections.Generic;
using UnityEngine.Events;

public class RaceEventBus
{
    private static readonly IDictionary<RaceEventType, UnityEvent> Events = new Dictionary<RaceEventType, UnityEvent>();

    public static void Subscribe(RaceEventType eventType, UnityAction listener)
    {
        // 딕셔너리를 참조하여 딕셔너리에 해당 값이 있으면 구독자만 등록
        if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
            thisEvent.AddListener(listener);
        
        // 없으면 새로운 데이터를 만들어 구독자 등록
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe(RaceEventType eventType, UnityAction listener)
    {
        if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
            thisEvent.RemoveListener(listener);
    }

    public static void Publish(RaceEventType eventType)
    {
        if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
            thisEvent.Invoke();
    }
}