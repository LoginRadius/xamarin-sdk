using System.Collections.Generic;


namespace XamarinSDK.Models
{
    public class LoginRadiusRoles: LoginRadiusRolePermissions
    {
        public string Name { get; set; }
        
    }

    public class LoginRadiusRolePermissions 
    {
        public Dictionary<string, bool> Permissions { get; set; }
    }

    public class LoginRadiusRolesCreate 
    {
       public List<LoginRadiusRoles> Roles { get; set; } 
    }
}
