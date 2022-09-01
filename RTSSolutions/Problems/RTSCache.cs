using RtsSolutions.Problems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSSolutions.Problems
{
    public class RTSCache<T> : ICache<T> where T : class
    {
        private OrderedDictionary Data { get; set; } = new();

        public int MaxCacheSize { get; private set; } = 3;


        public T Get(string key)
        {
            if (Data.Contains(key))
            {
                return (T)Data[key];
            }
            else
            {
                return null;
            }
        }

        public int GetCurrentCacheSize()
        {
            return Data.Count;
        }

        public int GetMaxSize()
        {
            return MaxCacheSize;
        }

        public void Put(string key, T value)
        {
            if (GetCurrentCacheSize() == GetMaxSize())
            {
                RemoveOldestKey();
                Data.Add((string)key, (T)value);
            }
            else
            {
                Data.Add((string)key, (T)value);
            }
        }

        public void SetMaxSize(int maxSize)
        {
            if (maxSize < GetCurrentCacheSize())
            {
                int curSize = GetCurrentCacheSize();

                while (curSize > maxSize)
                {
                    RemoveOldestKey();
                    curSize--;
                }

                MaxCacheSize = maxSize;
            }
            else
            {
                MaxCacheSize = maxSize;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var item in GetKeys())
            {
                builder.AppendLine($"{item} : {Get(item)}");
            }

            return builder.ToString();
        }

        private void RemoveOldestKey()
        {
            if (Data.Count >= 1)
            {
                Data.Remove(GetKeys().FirstOrDefault());
            }
        }

        private IEnumerable<string> GetKeys()
        {
            return Data.Keys.OfType<string>();
        }
    }
}
