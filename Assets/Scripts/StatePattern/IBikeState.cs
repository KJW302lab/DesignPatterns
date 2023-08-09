using StatePattern;

public interface IBikeState
{
    void Handle(BikeController controller);
}