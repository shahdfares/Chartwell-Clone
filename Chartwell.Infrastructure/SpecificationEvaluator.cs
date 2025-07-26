using Chartwell.Core.Entity;
using Chartwell.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure
{
    public class SpecificationEvaluator <TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;     // _dbContext.Set<Product>()

            //Where
            if (spec.Criteria is { })  // P => P. Id == id 
                query = query.Where(spec.Criteria);

            /*Include
             * P =. P.Brand
             * P => P.Category
             */

            //Include
            query = spec.Include.Aggregate(query, (currentQuery, inputExpression) => currentQuery.Include(inputExpression));

            return query;
        }
    }
}
