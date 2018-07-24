using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Interfaces;

namespace Task5
{
    public class DataBase<T> : IBaseService<T> where T : class, new()
    {
        private T Getted;

        public List<User> DataBaseEmulator = new List<User>()
        {
            new User(){ Id = 1 },

            new User(){ Id = 2 },

            new User(){ Id = 3 },

            new User(){ Id = 4 },

            new User(){ Id = 5 },
        };

        public bool Delete(int id = default)
        {
            try
            {
                foreach (var user in DataBaseEmulator)
                {
                    if (user.Id == id)
                    {
                        DataBaseEmulator.Remove(user);

                        return true;
                    }
                }

                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public T Get(int id = default)
        {
            foreach (var user in DataBaseEmulator)
            {
                if (user.Id == id)
                {
                    Getted = user as T;
                }
                else
                {
                    Getted = null;
                }
            }

            return Getted;
        }

        public List<T> GetAll()
        {
            return DataBaseEmulator as List<T>;
        }

        public bool Save(T entity = default)
        {
            if (entity as User == null)
            {
                return false;
            }
            else
            {
                DataBaseEmulator.Add(entity as User);

                return true;
            }
        }
    }
}
