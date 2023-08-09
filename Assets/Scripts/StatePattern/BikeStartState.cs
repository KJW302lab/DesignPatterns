using System;
using StatePattern;
using UnityEngine;

public class BikeStartState: MonoBehaviour, IBikeState
{
    private BikeController _bikeController;

    public void Handle(BikeController bikeController)
    {
        if (!_bikeController)
            _bikeController = bikeController;

        _bikeController.CurrentSpeed = bikeController.maxSpeed;
    }

    private void Update()
    {
        if (_bikeController)
        {
            if (_bikeController.CurrentSpeed > 0f)
            {
                var speed = _bikeController.CurrentSpeed * Time.deltaTime;
                _bikeController.transform.Translate(Vector3.forward * speed);
            }
        }
    }
}