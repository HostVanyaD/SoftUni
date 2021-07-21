using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var circle = new Circle();
            var rectangle = new Rectangle();
            var square = new Square();

            GraphicEditor graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(square);
            graphicEditor.DrawShape(circle);
            graphicEditor.DrawShape(rectangle);

            var triangle = new Triangle();

            graphicEditor.DrawShape(triangle);
        }
    }
}
