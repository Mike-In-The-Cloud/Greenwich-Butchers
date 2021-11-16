using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Utility
{
    // this class holds information that will not change during the application cycle
    // using const variables these cannot be changed and cannot be modified
    // eliminating the use of "magic strings" and typos within the application
    public class StaticDetails
    {
        //default image location if not image is supplied when creating a new product
        public const string DefaultProductImage = "default_image.png";
        // file location for product images to be stored on the host machine
        public const string ImageFolder = @"Images\ProductImage";

        // strings used to assign the roles to the user 
        // customer role
        public const string CustomerUser = "Customer";
        // admin role
        public const string AdminUser = "Admin";
        // super admin role
        public const string SuperAdminUser = "Super Admin";



        // const strings for order status
        public const string OrderStatusPending = "Pending";
        public const string OrderStatusInProgress = "In Progress" ;
        public const string OrderStatusComplete = "Complete";
        public const string OrderStatusRejected = "Rejected";
        public const string OrderStatusError = "Uh Oh! Something Went Wrong!";

        // constatnt ints for the value of bulk order status

        public const int OrderStatusZero = 0;
        public const int OrderStatusOne = 1;
        public const int OrderStatusTwo = 2;
        public const int OrderStatusThree = 3;


        // constatnt strings for setting employee type
        public const string EmpPt = "Part Time";
        public const string EmpFt = "Full Time";
    }
}
