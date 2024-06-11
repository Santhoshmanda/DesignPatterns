using System;
using System.Collections;

namespace Design_Patterns.Behavioral.Iterator2
{
	public class Enumerableexample
	{
		public Enumerableexample()
		{
		}
	}


    /* 
	 * IEnumerable
	 *  ICollection
	 *   IList
	 *   IDictionary

	//Concrete Aggerage
	 IList: Icollection and IEnumerable

	//Aggreagte
	public interface IEnumerable{

	  IEnumerator GetEnumerator(); //this has to be implemented in every collection class so that the for each loop works
	  
	}

    public Interface Ienumerator{ //iterator
    current,movenext etc

    }


	 */

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

    public class BookIterator : IEnumerator
    {
        Book book;
        private Library lib;

        private int Currentindex = -1;

        public BookIterator(Library lib)
        {
            this.lib = lib;
        }

        public object Current { get { return book; }}

        //public bool hasNext()
        //{
        //    return index < books.Count;
        //}

        public bool MoveNext()
        {
            if (Currentindex++ >= lib.Count)
            {
                return false;
            }
            else
            {
                book = lib[Currentindex];
                return true;
            }
        }

        //public object Next()
        //{
        //    if (this.hasNext())
        //    {
        //        return books[index++];
        //    }
        //    return null;

        //}

        public void Reset()
        {
           // index = 0;
        }
    }

    public interface Aggregate   // IEnumerable
    {
        Iterator CreateIterator();

    }

    public class Library : IEnumerable
    {
        private List<Book> bookList;

        public Library(List<Book> bookList)
        {
            this.bookList = bookList;

        }
        public int Count { get { return bookList.Count; } }

        public Book this[int index] { get { return bookList[index]; } }

        //public Iterator CreateIterator()
        //{
        //    return new BookIterator(bookList);
        //}

        public IEnumerator GetEnumerator()
        {
           return new BookIterator(this);
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
            //Iterator iterator = lib.CreateIterator();
            //while (iterator.hasNext())
            //{
            //    Book book = (Book)iterator.Next();
            //    Console.Write(book.BookName);
            //}
            //or
            foreach (Book book in lib)
            {
                Console.Write(book.BookName);
            }

        }
    }







    }

