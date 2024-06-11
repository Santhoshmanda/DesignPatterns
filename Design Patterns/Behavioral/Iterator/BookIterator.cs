using System;
namespace Design_Patterns.Behavioral.Iterator
{

	// provide access to elements of a collection sequentially without exposing the underlying representation of the collection
	// 1. Iterator interface: next and hasNext() 2. Concrete Iterator (there can be many concrete iterators)
	//3. Aggregate(maintains collection):Create Iterator 4. Concrete aggregator(there can be many concrete iterators)
	//eg book and Library

	public class Book
	{
		public int Price { get; set; }
		public string BookName { get; set; }
        public Book(string bookName, int price)
		{
			this.Price = price;
			this.BookName = bookName;
		}
	}


	public interface Iterator // IEnumerator
	{
		bool hasNext();
		Object Next();
	}

    public class BookIterator : Iterator
    {
		private List<Book> books;
		private int index = 0;

		public BookIterator(List<Book> books)
		{
			this.books = books;
		}

        public bool hasNext()
        {
			return index < books.Count;
        }

        public object Next()
        {
			if (this.hasNext())
			{
				return books[index++];
			}
			return null;
            
        }
    }

	public interface Aggregate   // IEnumerable
	{
		Iterator CreateIterator();

    }

	public class Library:Aggregate
	{
		private List<Book> bookList;

		public Library(List<Book> bookList)
		{
			this.bookList = bookList;

		}

		public Iterator CreateIterator()
		{
			return new BookIterator(bookList);
		}


	}


	//client
	public class Client
	{
		public void TestMethod()
		{
            List<Book> bookList = new List<Book> {
            new Book("Dopamine Detox",120),
            new Book("Dopamine Detox",120)

        };

            Library lib = new Library(bookList);
			Iterator iterator=lib.CreateIterator();
			while (iterator.hasNext())
			{
				Book book = (Book)iterator.Next();
				Console.Write(book.BookName);
			}
			//or
			//foreach(Book book in lib)
			//{
				
			//}

        }
		

	}





}

