using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.DAL
{
    interface IAuthorRepository
    {
        List<Scratch> GetAuthors(int amount, string sort);
        Scratch GetSingleAuthor(int authorId);
        bool InsertAuthor(Scratch newAuthor);
        bool DeleteAuthor(int authorId);
        bool UpdateAuthor(int id, Scratch author);
    }
}
