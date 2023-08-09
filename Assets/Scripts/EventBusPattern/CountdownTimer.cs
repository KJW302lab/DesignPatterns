using System.Collections;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private float _currentTime;
    private readonly float _duration = 3.0f;

    private void OnEnable()
    {
        // 해당 게임 오브젝트가 활성화(ActiveSelf = true)가 될 때 StartTimer 메서드 등록
        RaceEventBus.Subscribe(RaceEventType.CountDown, StartTimer);
    }

    private void OnDisable()
    {
        // 해당 게임 오브젝트가 비활성화(ActiveSelf = false)가 될 때 메서드 등록 해제
        RaceEventBus.Unsubscribe(RaceEventType.CountDown, StartTimer);
    }

    private void StartTimer()
    {
        StartCoroutine(nameof(Countdown));
    }

    IEnumerator Countdown()
    {
        _currentTime = _duration;

        while (_currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }
        
        // 카운트 다운이 완료되면 Start 이벤트 게시
        RaceEventBus.Publish(RaceEventType.Start);
    }

    private void OnGUI()
    {
        GUI.color = Color.blue;
        GUI.Label(new Rect(125f, 0f, 100f, 20f), "COUNTDOWN :" + _currentTime);
    }
}