using Database.Models;
using Database.Repositories;

namespace Database
{
    public class GamesService(GamesRepository repository)
    {
        private GamesRepository _repository = repository;

        public IEnumerable<Game> GetAll(out string log)
        {
            log = "Получены все объекты";
            return _repository.GetAll();
        }

        public Game? GetById(int id, out string log)
        {
            log = "Некорректные данные";
            if (!CheckId(id))
                return null;

            log = "Получен объект";
            return _repository.GetById(id);
        }

        public void Create(Game game, out string log)
        {
            log = "Некорректные данные";
            if (!CheckPrice(game.Price))
                return;
            if (!CheckPublicationYear(game.PublicationYear))
                return;
            if (!CheckTitle(game.Title))
                return;

            log = "Создан объект";
            _repository.Create(game);
        }

        public void Update(Game game, out string log)
        {
            log = "Некорректные данные";
            if (!CheckId(game.Id))
                return;
            if (!CheckPrice(game.Price))
                return;
            if (!CheckPublicationYear(game.PublicationYear))
                return;
            if (!CheckTitle(game.Title))
                return;

            log = "Обновлен объект";
            _repository.Update(game);
        }

        public void Delete(int id, out string log)
        {
            log = "Некорректные данные";
            if (!CheckId(id))
                return;

            log = "Удален объект";
            _repository.Delete(id);
        }

        public bool CheckId(int id)
        => id > 0;

        public bool CheckPrice(double price)
        => price >= 0;

        public bool CheckPublicationYear(int publicationYear)
        => publicationYear > 1900;

        public bool CheckTitle(string title)
        => title != String.Empty;
    }
}
