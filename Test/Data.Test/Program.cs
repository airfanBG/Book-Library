using BookLibrary.Data;
using BookLibrary.Data.Repository;
using BookLibrary.Models;
using Microsoft.Data.SqlClient;
using System;
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
            using (LibraryDbContextRepository db = new LibraryDbContextRepository(new LibraryDbContext()))
            {
                var res = db.Books.GetAll().ToList();
            }
            //using (BaseRepository<Book,string> db = new BaseRepository<Book, string>())
            //{
            //    var res = db.GetAll().ToList();
            //}
            //SqlConnection connection = new SqlConnection(@"Data Source=airfan\SQLEXPRESS;Initial Catalog=Library;Trusted_Connection=True;");
            //string query = "select * from aspnetusers";

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
        }
    }
}
