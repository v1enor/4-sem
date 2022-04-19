using  System.Drawing;

namespace lab4_2
{
    public class Planet
    {
        private Brush color;
        private int size;
        private int distanse;

        public int Size { get => size; set => size = value; }
        public int Distanse { get => distanse; set => distanse = value; }
        public Brush Color { get => color; set => color = value; }

        public Planet(int size, int dist, System.Drawing.Brush color)
        {
            this.Size = size;
            Distanse = dist;
            this.Color = color;
        }

        public void Fill(Graphics gr, float x, float y)
        {
            gr.FillEllipse(Color, x, y, Size, Size);
        }

    }
}
