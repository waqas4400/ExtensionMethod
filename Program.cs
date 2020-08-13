using System;
using System.Collections.Generic;

namespace CSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = Books.CreatBook("C Sharp")
                            .AddAuthor("Waqas")
                            .PublisheOn(2020)
                            .AddGenres(Genre.Action)
                            .AddGenres(Genre.Animated)
                            .AddGenres(Genre.Horror)
                            .Build();
            Console.WriteLine("Book Title is:" + book.Title);
            Console.WriteLine("Book Author is:" + book.Author);
            Console.WriteLine("Book Published On:" + book.PublishedOn);
            foreach(var gen in book.Genres)
            {
                Console.WriteLine("Book Genre is:" + gen);
            }
        }
    }
    public enum Genre
    {
        Action = 1,
        Horror,
        Animated,
        Drama
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedOn { get; set; }
        public List<Genre> Genres { get; set; }
        public Book()
        {
            Genres = new List<Genre>();
        }
    }
    public class Books
    {
        public static BookBuilder CreatBook(string title)
        {
            var builder = new BookBuilder();
            builder.Title = title;
            return builder;
        }
    }
    public static class BookExtension
    {
        public static BookBuilder AddAuthor(this BookBuilder builder, string author)
        {
            builder.Author = author;
            return builder;
        }
        public static BookBuilder PublisheOn(this BookBuilder builder, int publishedOn)
        {
            builder.PublishedOn = publishedOn;
            return builder;
        }
        public static BookBuilder AddGenres(this BookBuilder builder, Genre genre)
        {
            builder.Genres.Add(genre);
            return builder;
        }
    }
    public class BookBuilder
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedOn { get; set; }
        public List<Genre> Genres { get; set; }
        public BookBuilder()
        {
            Genres = new List<Genre>();
        }
        public Book Build()
        {
            var book = new Book();
            book.Title = Title;
            book.Author = Author;
            book.PublishedOn = PublishedOn;
            foreach (var gen in Genres)
            {
                book.Genres.Add(gen);
            }
            return book;
        }
    }
}
