using Database.Database;
using Database.Models;
using Database.Repositories;
using Database.Services;
using System.Windows;

namespace LabWork47
{
    /// <summary>
    /// Логика взаимодействия для Task4.xaml
    /// </summary>
    public partial class Task4 : Window
    {
        public static IDatabaseFactory factory = new MsSqlFactory("Data Source=zombatka;Integrated Security=True;Trust Server Certificate=True");
        public static GamesRepository repository = new(factory);
        public static GamesService service = new(repository);
        public Task4()
        {
            InitializeComponent();
        }

        private void GetByIdButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(IdTextBox.Text, out id))
                return;

            string log;

            var game = service.GetById(id, out log);
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

            MessageBox.Show(log, "Лог", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            double price;
            if (!double.TryParse(PriceTextBox.Text, out price))
                return;
            int publicationYear;
            if (!int.TryParse(PublicationYearTextBox.Text, out publicationYear))
                return;

            string log;

            Game game = new()
            {
                Price = price,
                PublicationYear = publicationYear,
                Description = DescriptionTextBox.Text,
                Title = TitleTextBox.Text,
            };

            service.Create(game, out log);

            MessageBox.Show(log, "Лог", MessageBoxButton.OK, MessageBoxImage.Information);
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

            string log;

            Game game = new()
            {
                Id = id,
                Price = price,
                PublicationYear = publicationYear,
                Description = DescriptionTextBox.Text,
                Title = TitleTextBox.Text,
            };

            service.Update(game, out log);

            MessageBox.Show(log, "Лог", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(IdTextBox.Text, out id))
                return;

            string log;

            service.Delete(id, out log);

            MessageBox.Show(log, "Лог", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateTableButton_Click(object sender, RoutedEventArgs e)
        {
            string log;
            GamesDataGrid.ItemsSource = service.GetAll(out log);
            MessageBox.Show(log, "Лог", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
