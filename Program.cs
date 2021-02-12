using System;
using Box.V2;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models;
using Microsoft.Extensions.Configuration;

namespace BoxUserInvite
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string UserEmail = "sampleemail@abc.edu";        
            string UserId = "0123456789";
            var appConfig = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            var configJson = appConfig["BoxConfigJson"];
            System.Console.WriteLine($"Creating a Box Admin Client");

            var config = BoxConfig.CreateFromJsonString(configJson);
            var auth = new BoxJWTAuth(config);
            var adminToken = auth.AdminToken();
            var boxClient = auth.AdminClient(adminToken);
            System.Console.WriteLine($"Created a Box Admin Client");

            var inviteEmail = new BoxActionableByRequest() {Login = UserEmail};
            var inviteId = new BoxRequestEntity() { Id = UserId, Type = new BoxType()};
            System.Console.WriteLine($"Inviting User to enterprise account");
            boxClient.UsersManager.InviteUserToEnterpriseAsync(new BoxUserInviteRequest(){ Enterprise = inviteId, ActionableBy = inviteEmail});
            System.Console.WriteLine($"User invited to enterprise account");


        }
    }
}
