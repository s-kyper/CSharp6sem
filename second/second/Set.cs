using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace second
{
    public class Set<T> : IEnumerable
    {
        private SortedDictionary<T, int> data;
        private IComparer<T> comparer;

        public int Count => data.Count;

        public bool IsEmpty => data.Count == 0;

        public Set()
        {
            data = new SortedDictionary<T, int>();
            comparer = data.Comparer;
        }

        public Set(IComparer<T> comp)
        {
            comparer = comp;
            data = new SortedDictionary<T, int>(comp);
        }

        public Set(IEnumerable<T> enumerable, IComparer<T> comp)
        {
            comparer = comp;
            data = new SortedDictionary<T, int>(comp);
            foreach (var e in enumerable)
            {
                data.Add(e, 0);
            }
        }

        public bool Add(T item)
        {
            if (data.ContainsKey(item)) return false;
            data.Add(item, 0);
            return true;
        }

        public bool Remove(T item)
        {
            if (!data.ContainsKey(item)) return false;
            data.Remove(item);
            return true;
        }

        public bool Contains(T item)
        {
            return data.ContainsKey(item);
        }

        public Set<T> Where(Predicate<T> filter)
        {
            return new Set<T>(data.Keys.Where(new Func<T, bool>(filter)), comparer);
        }

        public override string ToString()
        {
            return data.Keys.Aggregate("Set: [ ", (current, item) => current + (item.ToString() + " ")) + "]";
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable) data).GetEnumerator();
        }

        public static Set<T> operator +(Set<T> left, Set<T> right)
        {
            foreach (KeyValuePair<T, T> r in right)
            {
                left.Add(r.Key);
            }
            return left;
        }

        public static Set<T> operator -(Set<T> left, Set<T> right)
        {
            foreach (KeyValuePair<T, T> r in right)
            {
                if (left.Contains(r.Key))
                {
                    left.Remove(r.Key);
                }
            }
            return left;
        }

        public static Set<T> operator *(Set<T> left, Set<T> right)
        {
            var res = new Set<T>();
            foreach (KeyValuePair<T, T> r in right)
            {
                if (left.Contains(r.Key))
                {
                    res.Add(r.Key);
                }
            }
            return res;
        }
    }
}