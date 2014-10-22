using AgetotonRPG.GameClasses;

namespace AgetotonRPG.GameInterfaces
{
    public interface IMovable
    {
        float X { get; set; }

        float Y { get; set; }

        bool CanMoveRight { get; set; }

        bool CanMoveLeft { get; set; }

        void WalkRight();

        void WalkLeft();

        void Move();
    }
}
