using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Articles_2._0
{
    class Program
    {
        static void Main()
        {
            int countArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            string[] input;

            for (int i = 0; i < countArticles; i++)
            {
                input = Console.ReadLine().Split(", ");

                var article = new Article(input[0], input[1], input[2]);

                articles.Add(article);

            }

            string orderByWhat = Console.ReadLine();

            switch (orderByWhat)
            {
                case "title":
                    articles = articles.OrderBy(X => X.Title).ToList();
                    break;

                case "content":
                    articles = articles.OrderBy(X => X.Content).ToList();
                    break;

                case "author":
                    articles = articles.OrderBy(X => X.Author).ToList();
                    break;
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string autor)
        {
            Title = title;
            Content = content;
            Author = autor;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}