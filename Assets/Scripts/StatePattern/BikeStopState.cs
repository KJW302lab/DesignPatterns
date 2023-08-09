using StatePattern;
using UnityEngine;

public class BikeStopState: MonoBehaviour, IBikeState
{
    private BikeController _bikeController;

    //바이크의 정지상태(stop)를 구현하기 위한 메서드
    public void Handle(BikeController bikeController)
    {
        if (!_bikeController)
            _bikeController = bikeController;

        //정지상태이므로 컨트롤러의 현재 속도를 0으로 설정한다.
        _bikeController.CurrentSpeed = 0;
    }
}