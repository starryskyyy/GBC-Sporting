using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GBCSporting_Flip_Framework.Models.DataLayer
{
    public class QueryOptions<T>
    {
        // public properties for sorting, filtering
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public string OrderByDirection { get; set; } = "asc";  // default

        public WhereClauses<T> WhereClauses { get; set; }
        public Expression<Func<T, bool>> Where
        {
            set
            {
                if (WhereClauses == null)
                {
                    WhereClauses = new WhereClauses<T>();
                }
                WhereClauses.Add(value);
            }
        }

        // private backing field for property and method that work with Include strings
        private string[] includes;

        // public write-only property for Include strings – converts comma-separated string to array 
        // and stores in private backing field
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }

        // public get method for Include strings - returns private backing field or empty string array 
        // if private backing field is null
        public string[] GetIncludes() => includes ?? new string[0];

        // read-only properties 
        public bool HasWhere => WhereClauses != null;
        public bool HasOrderBy => OrderBy != null;
    }

    // basically an alias for a list of where expressions - to make code clearer
    public class WhereClauses<T> : List<Expression<Func<T, bool>>> { }
}
