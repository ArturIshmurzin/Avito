using Avito.DataAccess.Interfaces.Repositories;
using Avito.Domain.Models;

namespace Avito
{
    public class TableWriter
    {
        public TableWriter(IUserRepository userRepository, IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;

        public void WriteTable()
        {
            Console.WriteLine("Введите название таблицы");

            switch (Console.ReadLine())
            {
                case "users":
                    this.WriteUser();
                    break;
                case "products":
                    this.WriteProduct();
                    break;
                case "reviews":
                    this.WriteReview();
                    break;
                default: Console.WriteLine("Таблицы не найдена");
                    break;
            }
        }

        private void WriteUser()
        {
            User user = new User();

            Console.WriteLine("Введите Имя");
            user.Name = Console.ReadLine()!;

            Console.WriteLine("Введите Номер телефона");
            user.PhoneNumber = Console.ReadLine()!;

            Console.WriteLine("Введите Почту");
            user.Email = Console.ReadLine()!;

            user.RegistrationDate = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Now.Day);

            _userRepository.Add(user);
            _userRepository.Save();

            Console.WriteLine($"Готово!");
        }

        private void WriteProduct()
        {
            Product product = new Product();

            Console.WriteLine("Введите Имя");
            product.Name = Console.ReadLine()!;

            Console.WriteLine("Введите описание");
            product.Description = Console.ReadLine()!;

            Console.WriteLine("Введите цену");
            product.Price = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Выберите пользователя который создает объявление");

            List<User> users = _userRepository.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Name}");
            }

            product.UserId = int.Parse(Console.ReadLine()!);

            product.Date = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Now.Day);

            _productRepository.Add(product);
            _productRepository.Save();

            Console.WriteLine($"Готово!");
        }

        private void WriteReview()
        {
            Review review = new Review();

            Console.WriteLine("Введите текст отзыва");
            review.Description = Console.ReadLine()!;

            List<User> users = _userRepository.GetAll();

            Console.WriteLine("Выберите пользователя который оставляет отзыв");

            foreach (User user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Name}");
            }

            review.AuthorId = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Выберите пользователя о котором отзыв");

            foreach (User user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Name}");
            }

            review.SalesmanId = int.Parse(Console.ReadLine()!);

            review.Date = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Now.Day);

            _reviewRepository.Add(review);
            _reviewRepository.Save();

            Console.WriteLine($"Готово!");
        }
    }
}
