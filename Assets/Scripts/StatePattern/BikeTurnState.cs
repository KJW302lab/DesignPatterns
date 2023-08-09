using StatePattern;
using UnityEngine;

public class BikeTurnState: MonoBehaviour, IBikeState
{
    private Vector3 _turnDirection;
    private BikeController _bikeController;

    public void Handle(BikeController bikeController)
    {
        if (!_bikeController)
            _bikeController = bikeController;

        _turnDirection.x = (float) _bikeController.CurrentTurnDirection;

        if (_bikeController.CurrentSpeed > 0f)
            transform.Translate(_turnDirection * bikeController.turnDistance);
    }
}