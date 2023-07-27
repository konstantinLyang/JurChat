using System.Collections;

namespace JurChat.Server
{
    class ConcurrentList<T> : IEnumerable<T>
    {
        private readonly List<T> _list;
        private readonly ReaderWriterLockSlim _lock;

        public ConcurrentList()
        {
            _list = new List<T>();
            _lock = new ReaderWriterLockSlim();
        }

        public void Add(T item)
        {
            _lock.EnterWriteLock();
            _list.Add(item);
            _lock.ExitWriteLock();
        }

        public void Remove(T item)
        {
            _lock.EnterWriteLock();
            _list.Remove(item);
            _lock.ExitWriteLock();
        }

        private IEnumerable<T> Enumerate()
        {
            _lock.EnterReadLock();
            try
            {
                foreach (T item in _list)
                    yield return item;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public IEnumerator<T> GetEnumerator()
            => Enumerate().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Enumerate().GetEnumerator();
    }
}
