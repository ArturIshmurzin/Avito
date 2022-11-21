using Avito.DataAccess.Interfaces.Repositories;
using Avito.Domain.Models;

namespace Avito
{
    public class TableReader
    {
        public TableReader(IUserRepository userRepository, IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository; 
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;

        public void ReadUserTable()
        {
            List<User> allUsers = _userRepository.GetAll();
            Console.WriteLine("Id  Name   PhoneNumber   Email                       RegistrationDate");

            foreach (User user in allUsers ) 
            {
                Console.WriteLine($"{user.Id}   {user.Name}   {user.PhoneNumber}   {user.Email}            {user.RegistrationDate}");
            }
        }

        public void ReadProductTable() 
        { 
            List<Product> allProducts = _productRepository.GetAll();

            Console.WriteLine("ID   Name   Description   Price   Date  User");

            foreach (Product product in allProducts ) 
            {
                Console.WriteLine($"{product.Id}   {product.Name}   {product.Description}   {product.Price}   {product.Date}   {product.User!.Name}");
            }
        }

        public void ReadReviewTable() 
        {
            List<Review> reviews= _reviewRepository.GetAll();

            Console.WriteLine($"Id     Author     Description     Date     Salesman");

            foreach (Review review in reviews)
            {
                Console.WriteLine($"{review.Id}   {review.Author!.Name}   {review.Description}   {review.Date}   {review.Salesman!.Name}");
            }
        }
    }
}
