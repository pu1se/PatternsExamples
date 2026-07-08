using System;
using static System.Console;

namespace ConsoleExample.Templates.Behavioral.MementoWithPreviousState;

public class MementoWithPreviousStateMainProgram
{
    public class BookMemento
    {
        public string Title { get; }
        public string Author { get; }
        public DateTime LastEdited { get; }

        public BookMemento(string title, string author, DateTime lastEdited)
        {
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }
        private BookMemento _previousState;

        public void SavePreviousState()
        {
            _previousState = new BookMemento(Title, Author, LastEdited);
        }

        public void RestorePreviousState()
        {
            if (_previousState == null)
                return;

            Title = _previousState.Title;
            Author = _previousState.Author;
            LastEdited = _previousState.LastEdited;
            _previousState = null;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, LastEdited: {LastEdited:d}";
        }
    }

    public static void RunCode()
    {
        var book = new Book
        {
            Title = "Harry Potter",
            Author = "Joan Rouling",
            LastEdited = DateTime.Now,
        };

        book.SavePreviousState();

        book.Title = "Edge of tomorrow";
        book.Author = "Mussimo";
        book.LastEdited = DateTime.Now;

        WriteLine(book);

        book.RestorePreviousState();

        WriteLine(book);
    }
}
