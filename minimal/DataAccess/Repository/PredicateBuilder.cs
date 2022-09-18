using System.Linq.Expressions;

namespace minimal.DataAccess.Repository;

// Based on: https://stackoverflow.com/questions/457316/combining-two-expressions-expressionfunct-bool
public static class PredicateBuilder
{
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
    {
        ParameterExpression p = a.Parameters[0];

        SubstExpressionVisitor visitor = new SubstExpressionVisitor();
        visitor.subst[b.Parameters[0]] = p;

        Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
        return Expression.Lambda<Func<T, bool>>(body, p);
    }

    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
    {
        ParameterExpression p = a.Parameters[0];

        SubstExpressionVisitor visitor = new SubstExpressionVisitor();
        visitor.subst[b.Parameters[0]] = p;

        Expression body = Expression.OrElse(a.Body, visitor.Visit(b.Body));
        return Expression.Lambda<Func<T, bool>>(body, p);
    }
}

public class SubstExpressionVisitor : ExpressionVisitor
{
    public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();
    protected override Expression VisitParameter(ParameterExpression node)
    {
        Expression newValue;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        if (subst.TryGetValue(node, out newValue))
        {
            return newValue;
        }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        return node;
    }
}