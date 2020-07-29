using System;
using System.Linq;
using System.Collections.Generic;

namespace Trabalho1.EstruturasDados
{
    //arrayList como estrtura de dados
    public class ArrayList<T> : IEnumerable<T>
    {
        
        // This sets the default maximum array length to refer to MAXIMUM_ARRAY_LENGTH_x64
        // Set the flag IsMaximumCapacityReached to false
        bool DefaultMaxCapacityIsX64 = true;
        bool IsMaximumCapacityReached = false;

        public const int MAXIMUM_ARRAY_LENGTH_x64 = 0X7FEFFFFF; //x64
        public const int MAXIMUM_ARRAY_LENGTH_x86 = 0x8000000; //x86

        private readonly T[] _emptyArray = new T[0];

        private const int _defaultCapacity = 8;

        private T[] _collection;

        private int _size { get; set; }

        public ArrayList() : this(capacity: 0) { }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (capacity == 0)
            {
                _collection = _emptyArray;
            }
            else
            {
                _collection = new T[capacity];
            }

            // Zerofiy the _size;
            _size = 0;
        }
   
        private void _ensureCapacity(int minCapacity)
        {
            if (_collection.Length < minCapacity && IsMaximumCapacityReached == false)
            {
                int newCapacity = (_collection.Length == 0 ? _defaultCapacity : _collection.Length * 2);
                int maxCapacity = (DefaultMaxCapacityIsX64 == true ? MAXIMUM_ARRAY_LENGTH_x64 : MAXIMUM_ARRAY_LENGTH_x86);

                if (newCapacity < minCapacity)
                    newCapacity = minCapacity;

                if (newCapacity >= maxCapacity)
                {
                    newCapacity = maxCapacity - 1;
                    IsMaximumCapacityReached = true;
                }

                this._resizeCapacity(newCapacity);
            }
        }

        private void _resizeCapacity(int newCapacity)
        {
            if (newCapacity != _collection.Length && newCapacity > _size)
            {
                try
                {
                    Array.Resize<T>(ref _collection, newCapacity);
                }
                catch (OutOfMemoryException)
                {
                    if (DefaultMaxCapacityIsX64 == true)
                    {
                        DefaultMaxCapacityIsX64 = false;
                        _ensureCapacity(newCapacity);
                    }
                    throw;
                }
            }
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public int Capacity
        {
            get { return _collection.Length; }
        }

        public bool IsEmpty
        {
            get
            {
                return (Count == 0);
            }
        }

        public T First
        {
            get
            {
                if (Count == 0)
                {
                    throw new IndexOutOfRangeException("List is empty.");
                }
                return _collection[0];
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                {
                    throw new IndexOutOfRangeException("List is empty.");
                }

                return _collection[Count - 1];
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                {
                    throw new IndexOutOfRangeException();
                }

                return _collection[index];
            }

            set
            {
                if (index < 0 || index >= _size)
                {
                    throw new IndexOutOfRangeException();
                }

                _collection[index] = value;
            }
        }

        /// <summary>
        /// Add the specified dataItem to list.
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        public void Add(T dataItem)
        {
            if (_size == _collection.Length)
            {
                _ensureCapacity(_size + 1);
            }

            _collection[_size++] = dataItem;
        }
        public void AddRange(IEnumerable<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException();

            // make sure the size won't overflow by adding the range
            if (((uint)_size + elements.Count()) > MAXIMUM_ARRAY_LENGTH_x64)
                throw new OverflowException();

            // grow the internal collection once to avoid doing multiple redundant grows
            if (elements.Any())
            {
                _ensureCapacity(_size + elements.Count());

                foreach (var element in elements)
                    this.Add(element);
            }
        }

        public void AddRepeatedly(T value, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            if (((uint)_size + count) > MAXIMUM_ARRAY_LENGTH_x64)
                throw new OverflowException();


            if (count > 0)
            {
                _ensureCapacity(_size + count);

                for (int i = 0; i < count; i++)
                    this.Add(value);
            }
        }

        public void InsertAt(T dataItem, int index)
        {
            if (index < 0 || index > _size)
            {
                throw new IndexOutOfRangeException("Please provide a valid index.");
            }

            if (_size == _collection.Length)
            {
                _ensureCapacity(_size + 1);
            }

            if (index < _size)
            {
                Array.Copy(_collection, index, _collection, index + 1, (_size - index));
            }
            _collection[index] = dataItem;
            _size++;
        }

        public bool Remove(T dataItem)
        {
            int index = IndexOf(dataItem);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("Please pass a valid index.");
            }
            _size--;
            if (index < _size)
            {
                Array.Copy(_collection, index + 1, _collection, index, (_size - index));
            }
            _collection[_size] = default(T);
        }

        public void Clear()
        {
            if (_size > 0)
            {
                _size = 0;
                Array.Clear(_collection, 0, _size);
                _collection = _emptyArray;
            }
        }

        public void Resize(int newSize)
        {
            Resize(newSize, default(T));
        }

        public void Resize(int newSize, T defaultValue)
        {
            int currentSize = this.Count;

            if (newSize < currentSize)
            {
                this._ensureCapacity(newSize);
            }
            else if (newSize > currentSize)
            {
                if (newSize > this._collection.Length)
                    this._ensureCapacity(newSize + 1);

                this.AddRange(Enumerable.Repeat<T>(defaultValue, newSize - currentSize));
            }
        }

        public void Reverse()
        {
            Reverse(0, _size);
        }

        public void Reverse(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= _size)
            {
                throw new IndexOutOfRangeException("Please");
            }

            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            Array.Reverse(_collection, startIndex, count);
        }
        
        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = 0; i < _size; ++i)
            {
                action(_collection[i]);
            }
        }

        public bool Contains(T dataItem)
        {
            // Null-value check
            if ((Object)dataItem == null)
            {
                for (int i = 0; i < _size; ++i)
                {
                    if ((Object)_collection[i] == null) return true;
                }
            }
            else
            {
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;

                for (int i = 0; i < _size; ++i)
                {
                    if (comparer.Equals(_collection[i], dataItem)) return true;
                }
            }
            return false;
        }

        public bool Contains(T dataItem, IEqualityComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            // Null-value check
            if ((Object)dataItem == null)
            {
                for (int i = 0; i < _size; ++i)
                {
                    if ((Object)_collection[i] == null) return true;
                }
            }
            else
            {
                for (int i = 0; i < _size; ++i)
                {
                    if (comparer.Equals(_collection[i], dataItem)) return true;
                }
            }
            return false;
        }

        public bool Exists(Predicate<T> searchMatch)
        {

            return (FindIndex(searchMatch) != -1);
        }

        public int FindIndex(Predicate<T> searchMatch)
        {
            return FindIndex(0, _size, searchMatch);
        }

        public int FindIndex(int startIndex, Predicate<T> searchMatch)
        {
            return FindIndex(startIndex, (_size - startIndex), searchMatch);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> searchMatch)
        {
            if (startIndex < 0 || startIndex > _size)
            {
                throw new IndexOutOfRangeException("Please pass a valid starting index.");
            }

            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            int endIndex = startIndex + count;
            for (int index = startIndex; index < endIndex; ++index)
            {
                if (searchMatch(_collection[index]) == true) return index;
            }
            return -1;
        }

        public int IndexOf(T dataItem)
        {
            return IndexOf(dataItem, 0, _size);
        }

        public int IndexOf(T dataItem, int startIndex)
        {
            return IndexOf(dataItem, startIndex, _size);
        }

        public int IndexOf(T dataItem, int startIndex, int count)
        {
            if (startIndex < 0 || (uint)startIndex > (uint)_size)
            {
                throw new IndexOutOfRangeException("Please pass a valid starting index.");
            }

            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }
            return Array.IndexOf(_collection, dataItem, startIndex, count);
        }

        public T Find(Predicate<T> searchMatch)
        {
            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < _size; ++i)
            {
                if (searchMatch(_collection[i]))
                {
                    return _collection[i];
                }
            }
            return default(T);
        }

        public ArrayList<T> FindAll(Predicate<T> searchMatch)
        {
            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            ArrayList<T> matchedElements = new ArrayList<T>();

            for (int i = 0; i < _size; ++i)
            {
                if (searchMatch(_collection[i]))
               {
                    matchedElements.Add(_collection[i]);
                }
            }
            return matchedElements;
        }

        public ArrayList<T> GetRange(int startIndex, int count)
        {
            if (startIndex < 0 || (uint)startIndex > (uint)_size)
            {
                throw new IndexOutOfRangeException("Please");
            }

            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            var newArrayList = new ArrayList<T>(count);
            Array.Copy(_collection, startIndex, newArrayList._collection, 0, count);
            newArrayList._size = count;

            return newArrayList;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Count];
            if (Count > 0)
            {
                Array.Copy(_collection, 0, newArray, 0, Count);
            }
            return newArray;
        }
        public List<T> ToList()
        {
            var newList = new List<T>(this.Count);
            if (this.Count > 0)
            {
                for (int i = 0; i < this.Count; ++i)
                {
                    newList.Add(_collection[i]);
                }
            }
            return newList;
        }
        public string ToHumanReadable(bool addHeader = false)
        {
            int i = 0;
            string listAsString = string.Empty;
            string preLineIndent = (addHeader == false ? "" : "\t");
            for (i = 0; i < Count; ++i)
            {
                listAsString = String.Format("{0}{1}[{2}] => {3}\r\n", listAsString, preLineIndent, i, _collection[i]);
            }
            if (addHeader == true)
            {
                listAsString = String.Format("ArrayList of count: {0}.\r\n(\r\n{1})", Count, listAsString);
            }
            return listAsString;
        }
        /********************************************************************************/

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _collection[i];
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}