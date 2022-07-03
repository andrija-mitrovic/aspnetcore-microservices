using System.Runtime.CompilerServices;

namespace Catalog.API.Helpers
{
    public static class HelperFunctions
    {
        public static string GetMethodName([CallerMemberName] string memberName = "")
        {
            return memberName;
        }
    }
}
