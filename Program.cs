using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    class Program
    {
        public const string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {

            }
        }

        #region Users

        public static void GetUsers(SqlConnection connection)
        {
            var userRepository = new GenericRepository<User>(connection);

            var users = userRepository.GetAll();

            if (!users.Any())
                Console.WriteLine("Nenhuma Role encontrada!");

            foreach (var user in users )
                Console.WriteLine($"Nome - {user.Name}");
        }
        public static void GetUsersWithRoles(SqlConnection connection)
        {
            var userRepository = new UserRepository(connection);
            var users = userRepository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine($"Nome - {user.Name}");
                foreach(var role in user.Roles)
                {
                    Console.WriteLine($"Role - {role.Name}");
                }
            }     
        }

        public static void CreateUser(SqlConnection connection)
        {
            var userRepository = new GenericRepository<User>(connection);

            var user = new User();

            user.Name = "Test";
            user.Email = "test.samuel@gmail.com";
            user.PasswordHash = "hash";
            user.Bio = "Teste insert usuario";
            user.Image = "https://";
            user.Slug = "Test";


            userRepository.Create(user);
        }

       public static void UpdateUser(SqlConnection connection)
        {
            var userRepository = new GenericRepository<User>(connection);

            var user = new User();

            user.Id = 6;
            user.Name = "Test Samuel";
            user.Email = "test.samuel@gmail.com";
            user.PasswordHash = "hash";
            user.Bio = "Teste insert usuario";
            user.Image = "https://";
            user.Slug = "Test-Samuel";


            userRepository.Update(user);
        }

        public static void DeleteUser(SqlConnection connection, int id)
        {
            var userRepository = new GenericRepository<User>(connection);

            userRepository.Delete(id);
        }

        public static void DeleteUser(SqlConnection connection)
        {
            var userRepository = new GenericRepository<User>(connection);

            var user = userRepository.GetById(6);

            userRepository.Delete(user);
        }

        #endregion Users

        #region Roles

        public static void GetRoles(SqlConnection connection)
        {
            var userRepository = new GenericRepository<Role>(connection);

            var roles = userRepository.GetAll();

            if (!roles.Any())
                Console.WriteLine("Nenhuma Role encontrada!");

            foreach (var role in roles)
                Console.WriteLine($"Nome - {role.Name}");
        }

        public static void CreateRole(SqlConnection connection)
        {
            var roleRepository = new GenericRepository<Role>(connection);

            var role = new Role();

            role.Name = "ADMIN";
            role.Slug = "Role-Admin";

            roleRepository.Create(role);
        }

        public static void UpdateRole(SqlConnection connection)
        {
            var roleRepository = new GenericRepository<Role>(connection);

            var role = new Role();

            role.Id = 2;
            role.Name = "Reader";
            role.Slug = "Reader";


            roleRepository.Update(role);
        }

        public static void DeleteRole(SqlConnection connection, int id)
        {
            var roleRepository = new GenericRepository<Role>(connection);

            roleRepository.Delete(id);
        }

        public static void DeleteRole(SqlConnection connection)
        {
            var roleRepository = new GenericRepository<Role>(connection);

            var role = roleRepository.GetById(2);

            roleRepository.Delete(role);  
        }

        #endregion Roles

        #region Tags
        public static void GetTags(SqlConnection connection)
        {
            var userRepository = new GenericRepository<Tag>(connection);

            var tags = userRepository.GetAll();

            if (!tags.Any())
                Console.WriteLine("Nenhuma Tag encontrada!");

            foreach (var tag in tags)
                Console.WriteLine($"Nome - {tag.Name}");
        }

        public static void CreateTag(SqlConnection connection)
        {
            var tagRepository = new GenericRepository<Tag>(connection);

            var tag = new Tag();

            tag.Name = "Futebol";
            tag.Slug = "Futebol";

            tagRepository.Create(tag);
        }

        public static void UpdateTag(SqlConnection connection)
        {
            var tagRepository = new GenericRepository<Tag>(connection);

            var tag = new Tag();

            tag.Id = 2;
            tag.Name = "Volei";
            tag.Slug = "Volei";

            tagRepository.Update(tag);
        }

        public static void DeleteTag(SqlConnection connection, int id)
        {
            var tagRepository = new GenericRepository<Tag>(connection);

            tagRepository.Delete(id);
        }

        public static void DeleteTag(SqlConnection connection)
        {
            var tagRepository = new GenericRepository<Tag>(connection);

            var tag = tagRepository.GetById(2);

            tagRepository.Delete(tag);
        }
        #endregion Tags
    }
}



