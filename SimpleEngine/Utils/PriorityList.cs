namespace SimpleEngine.Utils
{
    public class PriorityList<T>
    {
        private List<(T item, int priority)> _list;

        public int Count
        {
            get { return _list.Count; }
        }

        public PriorityList()
        {
            _list = new List<(T, int)>();
        }

        public void Add(T item, int priority)
        {
            _list.Add((item, priority));
            _list.Sort((x, y) => x.priority.CompareTo(y.priority));
        }

        public void Remove(T item)
        {
            int index = _list.FindIndex(tuple => EqualityComparer<T>.Default.Equals(tuple.item, item));
            if (index != -1)
            {
                _list.RemoveAt(index);
            }
        }

        public T this[int index]
        {
            get
            {
                return _list[index].item;
            }
            set
            {
                int priority = _list[index].priority;
                _list[index] = (value, priority);
            }
        }
    }
}

