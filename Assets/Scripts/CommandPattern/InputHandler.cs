using System;
using CommandPattern;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private BikeController _bikeController;
    private Command _buttonLeft, _buttonRight, _buttonForward;

    private void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _bikeController = FindObjectOfType<BikeController>();

        // 커맨드들을 초기화합니다.
        _buttonLeft = new TurnLeft(_bikeController);
        _buttonRight = new TurnRight(_bikeController);
        _buttonForward = new ToggleTurbo(_bikeController);
    }

    private void Update()
    {
        // 특정 키 입력을 각 커맨드에 매핑합니다.
        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKeyUp(KeyCode.A))
                _invoker.ExecuteCommand(_buttonLeft);
            
            if (Input.GetKeyUp(KeyCode.D))
                _invoker.ExecuteCommand(_buttonRight);
            
            if (Input.GetKeyUp(KeyCode.W))
                _invoker.ExecuteCommand(_buttonForward);
        }
    }

    private void OnGUI()
    {
        // 커맨드 기록을 시작하는 버튼을 추가합니다.
        if (GUILayout.Button("Start Recording"))
        {
            _bikeController.ResetPosition();
            _isReplaying = false;
            _isRecording = true;
            _invoker.Record();
        }

        // 커맨드 기록을 중지하는 버튼을 추가합니다.
        if (GUILayout.Button("Stop Recording"))
        {
            _bikeController.ResetPosition();
            _isRecording = false;
        }

        if (!_isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                _bikeController.ResetPosition();
                _isRecording = false;
                _isReplaying = true;
                _invoker.Replay();
            }
        }
    }
}