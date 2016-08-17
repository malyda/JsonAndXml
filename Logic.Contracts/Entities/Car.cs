namespace Parser.Logic.Contracts.Entities
{
    public class Car
    {
        public Car(int numberOfWheels, string color)
        {
            NumberOfWheels = numberOfWheels;
            Color = color;
        }

        public int NumberOfWheels { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            return "numberOfWheels: " + NumberOfWheels + " color: " + Color;
        }
    }
}