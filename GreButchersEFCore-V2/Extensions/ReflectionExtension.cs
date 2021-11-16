using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Extensions
{
    // static class
    // extension method to return the string name of an item
    public static class ReflectionExtension
    {
        /// <summary>
        /// This is an extension to get the value from a drop down list 
        /// created from the database
        /// </summary>
        /// <typeparam name="T"> generic list </typeparam>
        /// <param name="item"> items from the database </param>
        /// <param name="propertyName"> </param>
        /// <returns></returns>
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            // converts and returns a string of the name from a property from the drop down
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }
    }
}
