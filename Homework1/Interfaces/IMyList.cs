using System;
using System.Collections.Generic;
using System.Text;

namespace Homework1.Interfaces
{
    public interface IMyList<in TEntity>
    {
        public void Add(TEntity entity);
        public void AddRange(params TEntity[] entities);
        public bool Remove(TEntity entity);
        public void RemoveAt(int index);
        public void Sort();
    }
}
