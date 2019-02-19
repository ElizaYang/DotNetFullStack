using System;
using System.Collections.Generic;
using FriendsApp.API.Models;
using Newtonsoft.Json;

namespace FriendsApp.API.Data
{
    public class DataSeed
    {
        private readonly DataContext _context;

        public DataSeed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers() {
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            // convert json to users object
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            // loop through users to save to db
            foreach (var user in users) {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                // assign each user property
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();
                // insert new user to table
                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}