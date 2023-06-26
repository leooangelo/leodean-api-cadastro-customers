using System.Collections;

namespace MS.Customer.Domain.Helpers
{
    public static class ConvertToListHelper
    {
        public static bool Try(object obj)
        {
            try
            {
                _ = (IList)obj;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Any(object obj)
        {
            return ((IList)obj).Count > 0;
        }
    }
}
