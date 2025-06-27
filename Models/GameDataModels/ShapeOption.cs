using RockPaperScissors.Models.Enums;

namespace RockPaperScissors.Models.GameDataModels
{
    internal class ShapeOption
    {
        internal ShapeOption(Shape shape, List<Shape> inferiorShapes)
        {
            Shape = shape;
            Name = Enum.GetName(shape)!;
            InferiorShapes = inferiorShapes;
        }

        internal string Name { get; set; }
        internal Shape Shape { get; set; }
        internal ICollection<Shape> InferiorShapes { get; set; }

        internal bool BeatsShape(Shape shape)
        {
            return InferiorShapes.Contains(shape);
        }
    }
}
