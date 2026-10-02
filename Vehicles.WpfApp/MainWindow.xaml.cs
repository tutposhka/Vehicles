using System.Windows;
using System.Windows.Controls;
using Vehicles.Core;

namespace Vehicles.WpfApp
{
    public partial class MainWindow : Window
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public MainWindow()
        {
            InitializeComponent();

            TypeComboBox.SelectedIndex = 0;

            RefreshList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string make = MakeTextBox.Text.Trim();
            string model = ModelTextBox.Text.Trim();

            if (make == "" || model == "")
            {
                MessageBox.Show("Enter make and model");
                return;
            }

            if (TypeComboBox.SelectedItem is not ComboBoxItem item)
            {
                MessageBox.Show("Select vehicle type");
                return;
            }

            string type = item.Content.ToString() ?? "";

            Vehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(make, model);
            }
            else if (type == "Boat")
            {
                vehicle = new Boat(make, model);
            }
            else
            {
                vehicle = new AmphibiousCar(make, model);
            }

            vehicles.Add(vehicle);

            LogListBox.Items.Add(
                $"Added {vehicle.GetType().Name}: {make} {model}");

            MakeTextBox.Clear();
            ModelTextBox.Clear();

            RefreshList();
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            int index = VehiclesListBox.SelectedIndex;

            if (index < 0 || index >= vehicles.Count)
            {
                MessageBox.Show("Select vehicle");
                return;
            }

            try
            {
                Vehicle vehicle = vehicles[index];

                string message = vehicle.Move(10);

                LogListBox.Items.Add(message);

                RefreshList();

                VehiclesListBox.SelectedIndex = index;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Drive_Click(object sender, RoutedEventArgs e)
        {
            int index = VehiclesListBox.SelectedIndex;

            if (index < 0 || index >= vehicles.Count)
            {
                MessageBox.Show("Select vehicle");
                return;
            }

            Vehicle vehicle = vehicles[index];

            if (vehicle is IDriveable driveable)
            {
                try
                {
                    string message = driveable.Drive(5);

                    LogListBox.Items.Add(message);

                    RefreshList();

                    VehiclesListBox.SelectedIndex = index;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("This vehicle cannot drive");
            }
        }

        private void Swim_Click(object sender, RoutedEventArgs e)
        {
            int index = VehiclesListBox.SelectedIndex;

            if (index < 0 || index >= vehicles.Count)
            {
                MessageBox.Show("Select vehicle");
                return;
            }

            Vehicle vehicle = vehicles[index];

            if (vehicle is ISwimmable swimmable)
            {
                try
                {
                    string message = swimmable.Swim(5);

                    LogListBox.Items.Add(message);

                    RefreshList();

                    VehiclesListBox.SelectedIndex = index;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("This vehicle cannot swim");
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            int index = VehiclesListBox.SelectedIndex;

            if (index < 0 || index >= vehicles.Count)
            {
                MessageBox.Show("Select vehicle");
                return;
            }

            vehicles.RemoveAt(index);

            RefreshList();
        }

        private void RefreshList()
        {
            VehiclesListBox.ItemsSource = null;
            VehiclesListBox.ItemsSource = vehicles;
        }
    }
}