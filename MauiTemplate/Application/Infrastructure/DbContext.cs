﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure
{
    public static class DbContext
    {
        public const string DatabaseFilename = "Database.db3";
        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
       SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
       SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
       SQLite.SQLiteOpenFlags.SharedCache;
       
        public static string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseFilename);
    }
}
