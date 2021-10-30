using System;
using System.Collections.Generic;
using System.Linq;

namespace LecturePractice
{
    public class Program
    {
        public class Article
        {
            public string Title { get; set; }

            public string Content { get; set; }

            public string Author { get; set; }
        }
        public static void Main()
        {
            var inputText = Console.ReadLine()
                .Split(", ")
                .ToList();

            var number = int.Parse(Console.ReadLine());

            var article = new Article
            {
                Title = inputText[0],
                Content = inputText[1],
                Author = inputText[2]
            };

            for (int i = 0; i < number; i++)
            {
                var newInput = Console.ReadLine()
                    .Split(':')
                    .Select(s => s.Trim())
                    .ToList();

                if (newInput[0] == "Edit")
                {
                    article.Content = newInput[1];
                }
                else if (newInput[0] == "ChangeAuthor")
                {
                    article.Author = newInput[1];
                }
                else if (newInput[0] == "Rename")
                {
                    article.Title = newInput[1];
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}