using Newtonsoft.Json;
using Rrezart.Vibe.Domain.Entities;
using Rrezart.Vibe.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rrezart.Vibe.Persistence
{
    public class VibeDbContextInitializer
    {
        public static void Initialize(VibeDbContext context)
        {
            new VibeDbContextInitializer().Seed(context);
        }
        private void Seed(VibeDbContext context)
        {
            SeedEnviroment(context);
            SeedGenres(context);
            SeedUser(context);
            SeedRoles(context);
        }
        private void SeedUser(VibeDbContext context)
        {
            if (context.Users.FirstOrDefault() != null) return;

            var users = JsonConvert.DeserializeObject<IList<User>>(ReadJson("users.json"));
            context.Users.AddRange(users);
            SeedUserClaims(context, users);
            context.SaveChanges();
        }
        private void SeedUserClaims(VibeDbContext context, IList<User> users)
        {
            foreach (var user in users)
            {
                var userClaims = new List<UserClaim>
                {
                    new UserClaim{UserId = user.Id,ClaimType="userId",ClaimValue=user.Id.ToString()},
                    new UserClaim{UserId = user.Id,ClaimType="Email",ClaimValue=user.Email},
                    new UserClaim{UserId = user.Id,ClaimType="UserName",ClaimValue=user.UserName},
                    new UserClaim{UserId = user.Id,ClaimType="FirstName",ClaimValue=user.FirstName},
                    new UserClaim{UserId = user.Id,ClaimType="LastName",ClaimValue=user.LastName},
                    new UserClaim{UserId = user.Id,ClaimType="EmailConfirmed",ClaimValue=user.EmailConfirmed.ToString()},
                    new UserClaim{UserId = user.Id,ClaimType="SecurityStamp",ClaimValue=user.SecurityStamp.ToString()},
                };
                context.UserClaims.AddRange(userClaims);
            }
        }

        private void SeedRoles(VibeDbContext context)
        {
            if (context.Roles.FirstOrDefault() != null) return;

            var roles = JsonConvert.DeserializeObject<IList<Role>>(ReadJson("roles.json"));
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }

        private void SeedEnviroment(VibeDbContext context)
        {

            if (context.Enviroments.FirstOrDefault() != null) return;
            var enviroments = JsonConvert.DeserializeObject<IList<Enviroment>>(ReadJson("enviroments.json"));
            context.Enviroments.AddRange(enviroments);
            context.SaveChanges();
        }

        private void SeedGenres(VibeDbContext context)
        {
            if (context.Genres.FirstOrDefault() != null) return;

            var genres = JsonConvert.DeserializeObject<IList<Genre>>(ReadJson("genres.json"));
            context.Genres.AddRange(genres);
            context.SaveChanges();
        }


        private string ReadJson(string fileName)
        {
            var assembly = typeof(VibeDbContext).Assembly;

            var resources = assembly.GetManifestResourceNames();

            using (Stream stream = assembly.GetManifestResourceStream(resources.First(x => x.Contains(fileName))))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
