using HsgsGsu.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HsgsGsu.Models
{
    public class GSUContext: DbContext

    {
        public DbSet<Sjantpic> Sjantpics { get; set; }

    }
}