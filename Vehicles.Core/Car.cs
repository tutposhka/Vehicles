namespace Vehicles.Core
{
    public class Car : Vehicle, IDriveable
    {
        public Car(string make, string model)
            : base(make, model)
        {
        }

        public string Drive(double km)
        {
            if (km <= 0)
            {
                throw new ArgumentException(
                    "Distance must be greater than 0");
            }

            AddKm(km);

            return $"{Make} {Model} drove {km:F1} km";
        }

        public override string Move(double km)
        {
            return Drive(km);
        }
    }
}