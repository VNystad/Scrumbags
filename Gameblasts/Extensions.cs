using System.Security.Claims;
using System.Security.Principal;

namespace Gameblasts.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserAboutInfo(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("AboutInfo");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserMemberTitle(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("MemberTitle");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserLocation(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Location");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserGender(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Gender");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserSocialMediaNames(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("SocialMediaNames");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserAge(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Age");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserPostCount(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("PostCount");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserRegisterDate(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("RegisterDate");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}