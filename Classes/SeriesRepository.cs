using System;
using System.Collections.Generic;
using AppSimples.Interfaces;

namespace AppSimples
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> listSeries = new List<Series>();
        public void Delete(int id)
        {
            listSeries[id].Erase();
        }

        public void Insert(Series entity)
        {
            listSeries.Add(entity);
        }

        public List<Series> ListSeries()
        {
            return listSeries;
        }

        public int NextID()
        {
            return listSeries.Count;
        }

        public Series ReturnByID(int id)
        {
            return listSeries[id];
        }

        public void Update(int id, Series entity)
        {
            listSeries[id] = entity;
        }
    }
}