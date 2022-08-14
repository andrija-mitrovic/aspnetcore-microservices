using System.Runtime.CompilerServices;

namespace Ordering.Application.Common.Helpers
{
    public static class HelperFunctions
    {
        public static string GetMethodName([CallerMemberName] string memberName = "")
        {
            return memberName;
        }
    }
}
