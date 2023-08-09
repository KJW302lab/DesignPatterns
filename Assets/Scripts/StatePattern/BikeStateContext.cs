using StatePattern;

public class BikeStateContext
{
    public IBikeState CurrentState { get; set; }

    private readonly BikeController _bikeController;

    // 클래스 초기화
    public BikeStateContext(BikeController bikeController)
    {
        _bikeController = bikeController;
    }

    // IBikeState 인터페이스의 Handle() 메서드를 호출하는 부분
    public void Transition()
    {
        CurrentState.Handle(_bikeController);
    }

    public void Transition(IBikeState state)
    {
        CurrentState = state;
        CurrentState.Handle(_bikeController);
    }
}