namespace Vehicles.Core
{
    public class Boat : Vehicle, ISwimmable
    {
        public Boat(string make, string model)
            : base(make, model)
        {
        }

        public string Swim(double km)
        {
            if (km <= 0)
            {
                throw new ArgumentException(
                    "Distance must be greater than 0");
            }

            AddKm(km);

            return $"{Make} {Model} swam {km:F1} km";
        }

        public override string Move(double km)
        {
            return Swim(km);
        }
    }
}