using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Security
{
    public class ClaimsParser
    {
        private const string DATA_KEY = "data";

        public static ClaimsIdentity Create<T>(T model) where T : UserModel
        {
            var claims = new ClaimsIdentity("Bearer");
            claims.AddClaim(new Claim("sub", model.Email));
            //claims.AddClaim(new Claim(DATA_KEY, JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling =  ReferenceLoopHandling.Ignore })));

            return claims;
        }

        public static T Parse<T>(ClaimsIdentity claims) where T : IIdentityModel, new()
        {
            var model = JsonConvert.DeserializeObject<T>(GetClaim<string>(claims, DATA_KEY));

            model.IsAuthenticated = claims.IsAuthenticated;

            return model;
        }

        private static T GetClaim<T>(ClaimsIdentity claims, String claimName)
        {
            var claim = claims.Claims.FirstOrDefault(x => x.Type == claimName);

            if (claim == null)
                return default(T);

            var converter = TypeDescriptor.GetConverter(typeof(T));

            if (!converter.IsValid(claim.Value))
                return default(T);

            return (T)converter.ConvertFromInvariantString(claim.Value);
        }
    }
}