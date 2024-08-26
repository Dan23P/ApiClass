using Homework2.Models;

namespace Homework2
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book ()
            {
                Author = "F. Scott Fitzgerald",
                Title = "The Great Gatsby",
            },
            new Book ()
            {
                Author = "Homer",
                Title = "Iliad"
            },
            new Book ()
            {
                Author = "Fyodor Dostoevsky",
                Title = "Crime and Punishment",
            },
        };
    }

}
