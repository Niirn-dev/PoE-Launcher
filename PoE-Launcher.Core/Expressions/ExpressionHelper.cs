using System;
using System.Linq.Expressions;
using System.Reflection;

namespace PoE_Launcher.Core
{
    /// <summary>
    /// Helper for expressions
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        /// Get value of the return value from the compiled expression
        /// </summary>
        /// <typeparam name="T">Type of the return value</typeparam>
        /// <param name="expression">Expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyType<T>(this Expression<Func<T>> expression) => expression.Compile().Invoke();

        /// <summary>
        /// Sets the underlying property value to the given value
        /// </summary>
        /// <typeparam name="T">The type of the property to set</typeparam>
        /// <param name="expression">The expression containing the property</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> expression, T value)
        {
            // Converts (lambda) expression () => some.Property to some.Property
            var property = (expression as LambdaExpression).Body as MemberExpression;

            // Get the property information so we can set it
            var propertyInfo = (PropertyInfo)property.Member;
            var target = Expression.Lambda(property.Expression).Compile().DynamicInvoke();

            // Set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
