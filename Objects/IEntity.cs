using TeamWork.Field;

namespace TeamWork.Objects
{
    public interface IEntity
    {
        Point2D Point { get; set; }

        int Speed { get; set; }
    }
}
