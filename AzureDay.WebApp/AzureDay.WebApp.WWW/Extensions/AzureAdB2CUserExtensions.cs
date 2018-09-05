namespace System.Security.Claims
{
    public static class AzureAdB2CUserExtensions
    {
        public static string GetFirstName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
        }
        
        public static string GetLastName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname");
        }
        
        public static string GetFullName(this ClaimsPrincipal principal)
        {
            return $"{principal.GetFirstName()} {principal.GetLastName()}";
        }
        
        public static string GetEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("emails");
        }
        
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier");
        }
        
        public static string GetIdentityProvider(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("http://schemas.microsoft.com/identity/claims/identityprovider");
        }
        
        public static string GetJobTitle(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("jobTitle");
        }
        
        public static string GetCompany(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("extension_Company");
        }
        
        public static string GetCountry(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("country");
        }
        
        public static string GetCity(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("city");
        }
    }
}