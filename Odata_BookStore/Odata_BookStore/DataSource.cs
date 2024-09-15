using Odata_BookStore.Models;

namespace Odata_BookStore
{
    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }

        public static IList<Book> GetBooks()
        {
            if (listBooks != null)
            {
                return listBooks;
            }

            listBooks = new List<Book>();

            listBooks.Add(new Book
            {
                Id = 1,
                ISBN = "978-0-321-87758-1",
                Title = "Essential C# 5.0",
                Author = "Mark Michaelis",
                Price = 59.99m,
                Location = new Address
                {
                    City = "HCM City",
                    Street = "D2, Thu Duc District"
                },
                Press = new Press
                {
                    Id = 1,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 2,
                ISBN = "978-0-596-52068-7",
                Title = "Learning Python",
                Author = "Mark Lutz",
                Price = 64.99m,
                Location = new Address
                {
                    City = "Hanoi",
                    Street = "D1, Ba Dinh District"
                },
                Press = new Press
                {
                    Id = 2,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 3,
                ISBN = "978-1-118-79432-0",
                Title = "JavaScript: The Good Parts",
                Author = "Douglas Crockford",
                Price = 39.99m,
                Location = new Address
                {
                    City = "Da Nang",
                    Street = "N3, Hai Chau District"
                },
                Press = new Press
                {
                    Id = 3,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 4,
                ISBN = "978-0-321-63537-2",
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Price = 49.99m,
                Location = new Address
                {
                    City = "HCM City",
                    Street = "D4, Binh Thanh District"
                },
                Press = new Press
                {
                    Id = 4,
                    Name = "Prentice Hall",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 5,
                ISBN = "978-1-491-90365-1",
                Title = "Design Patterns",
                Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                Price = 54.99m,
                Location = new Address
                {
                    City = "Hanoi",
                    Street = "D5, Cau Giay District"
                },
                Press = new Press
                {
                    Id = 5,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 6,
                ISBN = "978-1-449-37236-2",
                Title = "You Don't Know JS",
                Author = "Kyle Simpson",
                Price = 44.99m,
                Location = new Address
                {
                    City = "Da Nang",
                    Street = "N6, Ngu Hanh Son District"
                },
                Press = new Press
                {
                    Id = 6,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 7,
                ISBN = "978-0-672-33690-8",
                Title = "Effective Java",
                Author = "Joshua Bloch",
                Price = 59.99m,
                Location = new Address
                {
                    City = "HCM City",
                    Street = "D7, Phu Nhuan District"
                },
                Press = new Press
                {
                    Id = 7,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 8,
                ISBN = "978-0-201-48550-1",
                Title = "Introduction to Algorithms",
                Author = "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein",
                Price = 89.99m,
                Location = new Address
                {
                    City = "Hanoi",
                    Street = "D8, Thanh Xuan District"
                },
                Press = new Press
                {
                    Id = 8,
                    Name = "MIT Press",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 9,
                ISBN = "978-0-596-52068-7",
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt, David Thomas",
                Price = 49.99m,
                Location = new Address
                {
                    City = "Da Nang",
                    Street = "N9, Son Tra District"
                },
                Press = new Press
                {
                    Id = 9,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 10,
                ISBN = "978-0-13-708107-3",
                Title = "Refactoring",
                Author = "Martin Fowler",
                Price = 49.99m,
                Location = new Address
                {
                    City = "HCM City",
                    Street = "D10, Tan Binh District"
                },
                Press = new Press
                {
                    Id = 10,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 11,
                ISBN = "978-1-491-99469-6",
                Title = "Python Crash Course",
                Author = "Eric Matthes",
                Price = 39.99m,
                Location = new Address
                {
                    City = "Hanoi",
                    Street = "D11, Dong Da District"
                },
                Press = new Press
                {
                    Id = 11,
                    Name = "No Starch Press",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 12,
                ISBN = "978-0-470-22328-5",
                Title = "Head First Design Patterns",
                Author = "Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra",
                Price = 44.99m,
                Location = new Address
                {
                    City = "Da Nang",
                    Street = "N12, Lien Chieu District"
                },
                Press = new Press
                {
                    Id = 12,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 13,
                ISBN = "978-0-134-47556-3",
                Title = "Cracking the Coding Interview",
                Author = "Gayle Laakmann McDowell",
                Price = 49.99m,
                Location = new Address
                {
                    City = "HCM City",
                    Street = "D13, Go Vap District"
                },
                Press = new Press
                {
                    Id = 13,
                    Name = "CareerCup",
                    Category = Category.Book
                }
            });

            return listBooks;
        }
    }
}
