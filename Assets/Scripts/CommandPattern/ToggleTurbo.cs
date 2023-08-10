using CommandPattern;

public class ToggleTurbo : Command
{
    private BikeController _controller;

    public ToggleTurbo(BikeController bikeController)
    {
        _controller = bikeController;
    }
    
    public override void Execute()
    {
        _controller.ToggleTurbo();
    }
}