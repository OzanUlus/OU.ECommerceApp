﻿using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Persistance.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _context;

        public Repository(OrderContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var datas = await _context.Set<T>().ToListAsync();
            return datas;
        }

        public async Task<T> GetByFilterAsyns(Expression<Func<T, bool>> filter)
        {
            var datas =  await _context.Set<T>().SingleOrDefaultAsync(filter);
            return datas;
        }

        public async Task<T> GetByIdAsync(int id)
        {
           var data = await _context.Set<T>().FindAsync(id);
            return data;
        }

        public async Task UpdateAsync(T entity)
        {
           _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
