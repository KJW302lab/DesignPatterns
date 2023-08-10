using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    
    // SortedList를 이용하여 시간(_recordingTime)이 list에 추가될때 자동 정렬되도록 합니다.
    private SortedList<float, Command> _recordedCommands = new();

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (_isRecording)
            _recordedCommands.Add(_recordingTime, command);

        Debug.Log("Recorded Time : " + _recordingTime);
        Debug.Log("Recorded Command : " + command);
    }

    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;

        if (_recordedCommands.Count <= 0)
            Debug.LogError("No commands to replay!");

        _recordedCommands.Reverse();
    }

    private void FixedUpdate()
    {
        if (_isRecording)
            _recordingTime += Time.fixedDeltaTime;

        if (!_isReplaying) return;
        
        _replayTime += Time.deltaTime;

        // sortedList.Any()는 컬렉션에 요소가 하나라도 있는지 확인하고 bool을 return합니다.
        if (_recordedCommands.Any())
        {
            // Mathf.Approximately(a, b)는 두 변수가 근사한지 비교합니다.
            // if(float a == float b)처럼 float간의 '==' 비교 연산은 일치하지 않을때가 많기 때문에
            // Mathf.Approximately() 연산을 사용합니다.
            if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
            {
                Debug.Log("Replay Time : " + _replayTime);
                Debug.Log("Replay Command : " + _recordedCommands.Values[0]);
                    
                _recordedCommands.Values[0].Execute();
                _recordedCommands.RemoveAt(0);
            }
        }
        else
            _isReplaying = false;
    }
}