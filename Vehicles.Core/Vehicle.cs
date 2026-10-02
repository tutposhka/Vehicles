namespace Vehicles.Core
{
    public abstract class Vehicle
    {
        public string Make { get; }
        public string Model { get; }

        public double Odometer { get; private set; }

        protected Vehicle(string make, string model)
        {
            Make = make.Trim();
            Model = model.Trim();
            Odometer = 0;
        }

        public abstract string Move(double km);

        protected void AddKm(double km)
        {
            Odometer += km;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Make} {Model} | {Odometer:F1} km";
        }
    }
}