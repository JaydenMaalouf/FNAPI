using System;

using FortniteAPI.Classes;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Extensions
{
    public abstract class FNExtensions
    {
        public T GetUser<T>(string username) where T : IFNUser
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { username });
        }

        public T GetUser<T>(UID userID) where T : IFNUser
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { userID });
        }
    }
}
