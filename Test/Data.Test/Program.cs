using BookLibrary.Data;
using BookLibrary.Data.Repository;
using BookLibrary.Models;
using BookLibrary.Services.EntityServices;
using BooksLibrary.Services.EntityServices;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

namespace Data.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (LibraryDbContext context=new LibraryDbContext())
            //{
            //   var res= context.Users.ToList();
            //}
            //using (LibraryDbContextRepository db = new LibraryDbContextRepository(new LibraryDbContext()))
            //{
            //    var res = db.Books.GetAll().ToList();
            //}
            //using (BaseRepository<Book,string> db = new BaseRepository<Book, string>())
            //{
            //    var res = db.GetAll().ToList();
            //}
            SqlConnection connection = new SqlConnection(@"Data Source=airfan\SQLEXPRESS;Initial Catalog=Library;Trusted_Connection=True;");
            //string query = "select * from aspnetusers";
            string connstr = @"Data Source=airfan\SQLEXPRESS;Initial Catalog=Library;Trusted_Connection=True;";


            //using (connection)
            //{
            //    connection.Open();

            //    SqlCommand cmd = new SqlCommand(query,connection);

            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("\t{0}\t{1}\t{2}",
            //            reader[0], reader[1], reader[2]);
            //    }

            //    connection.Close();
            //}
            //using (connection)
            //{

            //    string add = "insert into Books (Id,Book_Name,Book_Pages,Book_Annotation, CreatedAt)"+"values (@Id, @Book_Name, @Book_Pages, @book_annotation, @createdat)";

            //    SqlCommand cmd = new SqlCommand(add, connection);
            //    cmd.Parameters.Add(new SqlParameter("@Id", "1231-dsaf-12sa-1111"));
            //    cmd.Parameters.Add(new SqlParameter("@Book_name", "Test from Ado"));
            //    cmd.Parameters.Add(new SqlParameter("@Book_pages", 100));
            //    cmd.Parameters.Add(new SqlParameter("@Book_annotation", "Test from Ado"));
            //    cmd.Parameters.Add(new SqlParameter("@CreatedAt", DateTime.Now));

            //    connection.Open();
            //    cmd.ExecuteNonQuery();
            //    connection.Close();
            //}
            //using (IDbConnection context=new SqlConnection(connstr))
            //{
            //    var res = context.Query<Book>("select * from books").ToList();

            //}
            //BookService service = new BookService(new BaseRepository<Book, string>());
            //var res=service.All().ToList();
            UserService userService = new UserService(new LibraryDbContext());
            var res = userService.All().ToList();
        }
    }
}
