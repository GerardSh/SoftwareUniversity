using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;

            private int index;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                index = -1;
            }

            public Book Current => books[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                index++;

                if (index < books.Count)
                {               
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
