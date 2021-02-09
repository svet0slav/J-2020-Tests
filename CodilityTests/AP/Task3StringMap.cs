using System;
using System.Collections.Generic;

namespace CodilityTests.AP
{
    // Do not change the name of this class
    public class StringMap<TValue> : IStringMap<TValue>
        where TValue : class
    {
        protected Dictionary<string, TValue> _list;

        /// <summary> Returns number of elements in a map</summary>
        public int Count
        {
            get
            {
                return _list == null ? 0 : _list.Count;
            }
        }

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        // Do not change this property
        public TValue DefaultValue { get; set; }

        public StringMap()
        {
            _list = new Dictionary<string, TValue>();
        }

        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in a map, then the value associated with this key should be overriden.
        /// </summary>
        /// <returns>true if the value for the key was overriden otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        public bool AddElement(string key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("Key is null");
            if (key.Length == 0)
                throw new ArgumentException("Key is empty");
            if (value == null)
                throw new ArgumentNullException("Value is null");

            if (_list.ContainsKey(key))
            {
                _list[key] = value;
                return true;
            }
            else
            {
                _list.Add(key, value);
                return false;
            }
        }

        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        public bool RemoveElement(string key)
        {
            if (key == null)
                throw new ArgumentNullException("Key is null");
            if (key.Length == 0)
                throw new ArgumentException("Key is empty");

            if (_list.ContainsKey(key))
            {
                _list.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If a key is null</exception>
        /// <exception cref="System.ArgumentException">If a key is an empty string</exception>
        public TValue GetValue(string key)
        {
            if (key == null)
                throw new ArgumentNullException("Key is null");
            if (key.Length == 0)
                throw new ArgumentException("Key is empty");

            if (_list.ContainsKey(key))
            {
                return _list[key];
            }
            else
            {
                return DefaultValue;
            }
        }
    }
}
