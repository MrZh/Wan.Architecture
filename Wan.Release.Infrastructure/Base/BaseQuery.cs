﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wan.Release.Infrastructure.Base
{
    public class BaseQuery
    {
        public string Sql { get; protected set; }

        public object Obj { get; protected set; }

        public BaseQuery(string sql, object obj)
        {
            Sql = sql;
            Obj = obj;
        }

        protected BaseQuery()
        {

        }
    }
}
