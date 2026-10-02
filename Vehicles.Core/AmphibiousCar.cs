namespace Vehicles.Core
{
    public class AmphibiousCar : Car, ISwimmable
    {
        private bool waterMode = false;

        public AmphibiousCar(string make, string model)
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
            string result;

            if (waterMode)
            {
                result = Swim(km);
            }
            else
            {
                result = Drive(km);
            }

            waterMode = !waterMode;

            return result;
        }
    }
}