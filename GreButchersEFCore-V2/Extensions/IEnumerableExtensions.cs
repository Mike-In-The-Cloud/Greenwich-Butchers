using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// This class structures the drop down menu for the category of a
        /// new product and editing a product
        /// </summary>
        /// <typeparam name="T"> This is the generic list </typeparam>
        /// <param name="items"> items from the category table </param>
        /// <param name="selectedValue"> the id of the selected value </param>
        /// <returns> an int values that corrisponds to the id of the category that has been selected</returns>
        /// 
        /// this method is to create a drop down list for the category list
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("CategoryName"),
                       Value = item.GetPropertyValue("CategoryId"),
                       Selected = item.GetPropertyValue("CategoryId").Equals(selectedValue.ToString())
                   };
        }


        /// this method is to create a dropdown list for suppliers in the database
        public static IEnumerable<SelectListItem> ToSelectListItem2<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("SupplierCompany"),
                       Value = item.GetPropertyValue("SupplierId"),
                       Selected = item.GetPropertyValue("SupplierId").Equals(Convert.ToInt32(selectedValue.ToString()))
                   };
        }
    }
}
