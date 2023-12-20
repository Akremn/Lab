namespace Lab_5_form
{
    public partial class Graphics : Form
    {
        private Square square;
        private Rhomb rhomb;
        private Circle circle;

        public Graphics()
        {
            InitializeComponent();

            square = new Square(200, 150, 100);
            rhomb = new Rhomb(200, 150, 100, 100);
            circle = new Circle(200, 150, 60);
        }

        private void button1_Click(object sen, EventArgs a)
        {
            square.MoveRight();
        }

        private void button2_Click(object sen, EventArgs a)
        {
            rhomb.MoveRight();
        }

        private void button3_Click(object sen, EventArgs a)
        {
            circle.MoveRight();
        }
        private void Form1_Load(object sen, EventArgs a)
        {
        }
    }

}