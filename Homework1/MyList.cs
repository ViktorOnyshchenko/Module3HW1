using Homework1.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Homework1
{
    public class MyList<TEntity> : IMyList<TEntity>, IEnumerable<TEntity> where TEntity : IComparable<TEntity>
    {
        private const int MinCapacity = 10;
        private int capacity;
        private int count;
        private TEntity[] entities;

        public int Capacity 
        {
            get
            {
                return capacity;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public MyList()
        {
            capacity = MinCapacity;
            count = 0;
            this.entities = new TEntity[capacity];
        }

        public MyList(TEntity[] entities)
        {
            capacity = entities.Length;
            count = entities.Length;
            this.entities = entities;
        }

        public void Add(TEntity entity)
        {
            if (count >= capacity)
            {
                capacity *= 2;
                TEntity[] newEntities = new TEntity[capacity];
                for (int index = 0; index < entities.Length; index++)
                {
                    newEntities[index] = entities[index];
                }
                entities = newEntities;
            }
            entities[count++] = entity;
        }

        public void AddRange(params TEntity[] entities)
        {
            foreach (var item in entities)
            {
                Add(item);
            }
        }

        public bool Remove(TEntity entity)
        {
            bool isRemoved = false;
            TEntity[] newEntities = new TEntity[capacity];
            for (int i = 0, j = 0; i < capacity; i++)
            {
                if(entities[i].Equals(entity))
                {
                    count--;
                    isRemoved = true;
                    continue;
                }
                newEntities[j] = entities[i];
                j++;
            }
            entities = newEntities;
            return isRemoved;
        }

        public void RemoveAt(int index)
        {
            if(index < 1 || index > count)
            {
                throw new ArgumentException("Index can't be less than one or greater than the number of elements!", nameof(index));
            }
            TEntity[] newEntities = new TEntity[capacity];
            index--;
            for (int i = 0, j = 0; i < capacity; i++)
            {
                if (i.Equals(index))
                {
                    count--;
                    continue;
                }
                newEntities[j] = entities[i];
                j++;
            }
            entities = newEntities;
        }

        public void Sort()
        {
            for (int i = 1; i < count; i++)
            {
                TEntity key = entities[i];
                int j = i;
                while ((j > 0) && (entities[j - 1].CompareTo(key) == 1))
                {
                    var temp = entities[j - 1];
                    entities[j - 1] = entities[j];
                    entities[j] = temp;
                    j--;
                }
                entities[j] = key;
            }
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            int counter = 0;
            foreach (var item in entities)
            {
                if(counter == count)
                {
                    yield break;
                }
                yield return item;
                counter++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
