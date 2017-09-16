﻿using System;
using System.Data.Entity;

namespace NorthWindCoreData
{
    public interface IDbContext:IDisposable
    {

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
       // int SaveChanges();
        
    }
}