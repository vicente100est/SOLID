using System;
using System.Collections.Generic;

namespace I
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class SaleServices : IBasicActions<Sale>
    {
        public void Add()
        {
            Console.WriteLine("Creamos la venta");
        }
        
        public Sale Get(int id)
        {
            return new Sale();
        }

        public List<Sale> GetList()
        {
            return new List<Sale>();
        }
    }

    public class UserService : IBasicActions<User>, IEdittableActions<User>
    {
        public void Add()
        {
            Console.WriteLine("Agregamos usuario...");
        }

        public void Delete(User entity)
        {
            Console.WriteLine("Eliminamos el usuario..");
        }

        public User Get(int id)
        {
            Console.WriteLine("Obtenemos el usuario...");
            return new User();
        }

        public List<User> GetList()
        {
            return new List<User>();
        }

        public void Update(User entity)
        {
            Console.WriteLine("Actualizamos el usuario...");
        }
    }

    public interface IBasicActions<T>
    {
        public T Get(int id);
        public List<T> GetList();
        public void Add();
    }

    public interface IEdittableActions<T>
    {
        public void Update(T entity);
        public void Delete(T entity);
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Sale
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
