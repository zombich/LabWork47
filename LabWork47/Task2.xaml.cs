using Database.Database;
using Database.Models;
using Database.Repositories;
using System.Windows;

namespace LabWork47
{
    /// <summary>
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public static IDatabaseFactory factory = new MsSqlFactory("Data Source=zombatka;Integrated Security=True;Trust Server Certificate=True");

        public static GamesRepository repository = new(factory);

        public Task2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GamesDataGrid.ItemsSource = repository.GetAll();
        }

        private void GetByIdButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(IdTextBox.Text, out id))
                return;

            var game = repository.GetById(id);
            if (game is not null)
                MessageBox.Show($@"
                                Title - {game.Title}
                                Price - {game.Price}
                                PublicationYear - {game.PublicationYear}
                                Description - {game.Description}",
                                "Game",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            else
                MessageBox.Show($@"Не удалось получить игру",
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            double price;
            if (!double.TryParse(PriceTextBox.Text, out price))
                return;
            int publicationYear;
            if (!int.TryParse(PublicationYearTextBox.Text, out publicationYear))
                return;

            Game game = new()
            {
                Price = price,
                PublicationYear = publicationYear,
                Description = DescriptionTextBox.Text,
                Title = TitleTextBox.Text,
            };

            repository.Create(game);

            MessageBox.Show($@"Успешно создано",
                                "Успех",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(IdTextBox.Text, out id))
                return;
            double price;
            if (!double.TryParse(PriceTextBox.Text, out price))
                return;
            int publicationYear;
            if (!int.TryParse(PublicationYearTextBox.Text, out publicationYear))
                return;

            Game game = new()
            {
                Id = id,
                Price = price,
                PublicationYear = publicationYear,
                Description = DescriptionTextBox.Text,
                Title = TitleTextBox.Text,
            };

            repository.Update(game);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(IdTextBox.Text, out id))
                return;

            repository.Delete(id);

            MessageBox.Show($@"Успешно удалено",
                    "Успех",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }

        private void UpdateTableButton_Click(object sender, RoutedEventArgs e)
        {
            GamesDataGrid.ItemsSource = repository.GetAll();
        }
    }
}
