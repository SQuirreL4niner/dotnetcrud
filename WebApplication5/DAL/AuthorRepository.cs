using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.DAL
{
    public class AuthorRepository : IAuthorRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public bool DeleteAuthor(int authorId)
        {
            int rowsAffected = this._db.Execute(@"DELETE FROM [Scratch] WHERE Id = @Id", new
            {
                Id = authorId
            });
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public List<Scratch> GetAuthors(int amount, string sort)
        {
            return this._db.Query<Scratch>("SELECT TOP " + amount +
                " [Id], [FirstName], [LastName], [IsActive] FROM [Scratch] ORDER BY Id " + sort).ToList();
        }

        public Scratch GetSingleAuthor(int authorId)
        {
            return _db.Query<Scratch>("SELECT[Id], [FirstName], [LastName], [IsActive] FROM [Scratch] WHERE Id = @Id", new
                {
                Id = authorId}).SingleOrDefault();
        }

        public bool InsertAuthor(Scratch newAuthor)
        {
            int rowsAffected = this._db.Execute(@"INSERT Scratch([Id], [FirstName], [LastName], [IsActive])
            values (@Id, @FirstName, @LastName, @IsActive)", new
            {
                Id = newAuthor.Id,
                FirstName = newAuthor.FirstName,
                LastName = newAuthor.LastName,
                IsActive = newAuthor.IsActive
            });
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateAuthor(int id, Scratch author)
        {
            int rowsAffected = this._db.Execute("UPDATE [Scratch] SET [FirstName] = @FirstName, [LastName]=@LastName, [IsActive]=@IsActive WHERE Id = " +
                author.Id, author);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}