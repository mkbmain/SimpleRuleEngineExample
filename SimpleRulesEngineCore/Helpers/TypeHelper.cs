using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleRulesEngineCore.Helpers
{
    public static class TypeHelper
    {
        internal static IEnumerable<Type> GetAllOfType<TInstance>(bool allowInterfaces = false, bool allowAbstractClasses = false)
        {
            var oob = Assembly.GetAssembly(typeof(TInstance)).GetTypes().Where(f => typeof(TInstance).IsAssignableFrom(f));

            if (!allowInterfaces)
            {
                oob = oob.Where(f => !f.IsInterface);
            }

            if (!allowAbstractClasses)
            {
                oob = oob.Where(f => !f.IsAbstract);
            }

            return oob;
        }
    }
}