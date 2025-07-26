using Chartwell.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Include { get; set; } = new List<Expression<Func<T, object>>>();



        public BaseSpecification()
        {
            // set Criteria null
            // Include = new List<Expression<Func<T, object>>> ();
        }

        public BaseSpecification(Expression<Func<T, bool>>? criteria)
        {
            Criteria = criteria;
            // Include = new List<Expression<Func<T, object>>>();
        }
    }
}
