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
    }
}