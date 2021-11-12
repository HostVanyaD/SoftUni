namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                // Problem 02 - Age Restriction
                //var command = Console.ReadLine();
                //Console.WriteLine(GetBooksByAgeRestriction(db, command));

                // Problem 03 - Golden Books
                //Console.WriteLine(GetGoldenBooks(db));

                // Problem 04 - Books by Price
                //Console.WriteLine(GetBooksByPrice(db));

                // Problem 05 - Not Released In
                //var year = int.Parse(Console.ReadLine());
                //Console.WriteLine(GetBooksNotReleasedIn(db, year));

                // Problem 06 - Book Titles by Category
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBooksByCategory(db, input));

                // Problem 07 - Released Before Date
                //var date = Console.ReadLine();
                //Console.WriteLine(GetBooksReleasedBefore(db, date));


                // Problem 08 - Author Search
                //var input = Console.ReadLine();
                //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

                // Problem 09 - Book Search
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBookTitlesContaining(db, input));

                // Problem 10 - Book Search by Author
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBooksByAuthor(db, input));

                // Problem 11 - Count Books
                //var input = int.Parse(Console.ReadLine());
                //Console.WriteLine(CountBooks(db, input));

                // Problem 12 - Total Book Copies
                //Console.WriteLine(CountCopiesByAuthor(db));

                // Problem 13 - Profit by Category
                //Console.WriteLine(GetTotalProfitByCategory(db));

                // Problem 14 - Most Recent Books
                //Console.WriteLine(GetMostRecentBooks(db));

                // Problem 15 - Increase Prices
               //IncreasePrices(db);

                // Problem 16 - Remove Books
                Console.WriteLine(RemoveBooks(db));
            }
        }

        // Problem 02 - Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            foreach (var book in books)
            {
                result.AppendLine($"{book}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 03 - Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var goldenBooks = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in goldenBooks)
            {
                result.AppendLine($"{book}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 04 - Boks By Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price})
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 05 - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var title in books)
            {
                result.AppendLine($"{title}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 06 - Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var books = context
                .Books
                .Where(b => b.BookCategories
                             .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        // Problem 07 - Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder result = new StringBuilder();

            var formattedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < formattedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                { 
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 08 - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        // Problem 09 - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 10 - Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var booksWithAuthors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            foreach (var bwa in booksWithAuthors)
            {
                result.AppendLine($"{bwa.Title} ({bwa.Author})");
            }            

            return result.ToString().TrimEnd();
        }

        // Problem 11 - Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.BookId)
                .ToList();

            return books.Count();
        }

        // Problem 12 - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var authorsWithBookCount = context.Authors
                .Select(a => new
                {
                    Name = a.FirstName + " " + a.LastName,
                    CountOfBooks = a.Books
                                    .Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CountOfBooks)
                .ToList();

            foreach (var author in authorsWithBookCount)
            {
                result.AppendLine($"{author.Name} - {author.CountOfBooks}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 13 - Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var profitByCategory = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    BooksProfit = c.CategoryBooks
                                    .Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.BooksProfit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var ctg in profitByCategory)
            {
                result.AppendLine($"{ctg.Name} ${ctg.BooksProfit:F2}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 14 - Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var mostRecentBooksByCategory = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    LatestBooks = c.CategoryBooks
                                   .Select(cb => new
                                   {
                                       Title = cb.Book.Title,
                                       ReleaseDate = cb.Book.ReleaseDate
                                   })
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in mostRecentBooksByCategory)
            {
                result.AppendLine($"--{category.Name}");

                foreach (var book in category.LatestBooks
                                             .OrderByDescending(lb => lb.ReleaseDate)
                                             .Take(3))
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return result.ToString().TrimEnd();
        }

        // Problem 15 - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var booksReleasedBefore = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in booksReleasedBefore)
            {
                book.Price += 5;
            }

            context.SaveChanges();

            Console.WriteLine("Prices has been updated!");
        }

        // Problem 16 - Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200);

            var deletedBooksCount = booksToDelete.Count();

            var booksCategories = context.BooksCategories
                .Where(bc => bc.Book.Copies < 4200);

            context.BooksCategories.RemoveRange(booksCategories);

            context.Books.RemoveRange(booksToDelete);

            context.SaveChanges();

            return deletedBooksCount;
        }
    }
}
