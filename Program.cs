using System;
using Box.V2;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models;
using Microsoft.Extensions.Configuration;

namespace BoxUserInvite
{
    /*
    1. Add User secrets, Box.v2.core nuget
    2. UserEmail, UserId
    3. create a box Admin client
    4. AdminToken 

    */

    class Program
    {
        public string UserEmail{get; set;}
        
        public string UserId{get; set;}

        static void Main(string[] args)
        {
            var appConfig = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            var configJson = appConfig["BoxConfigJson"];
            var config = BoxConfig.CreateFromJsonString(configJson);
            var auth = new BoxJWTAuth(config);
            var adminToken = auth.AdminToken();
            var boxClient = auth.AdminClient(adminToken);


            Console.WriteLine("Hello World!");
        }
    }
}
