using AzureDay.WebApp.Config;
using AzureDay.WebApp.Database;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.Database.Enums;
using AzureDay.WebApp.Notification;
using AzureDay.WebApp.WWW.Infrastructure;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AzureDay.WebApp.WWW.Service
{
    public sealed class AttendeeService
    {
        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            var entity = await DataFactory.AttendeeService.Value.GetByKeysAsync(Configuration.Year, email);

            return entity != null;
        }

        public async Task<Attendee> GetAttendeeByEmailAsync(string email)
        {
            var entity = await DataFactory.AttendeeService.Value.GetByKeysAsync(Configuration.Year, email);

            if (entity == null)
            {
                return null;
            }

            return AppFactory.Mapper.Value.Map<Attendee>(entity);
        }

        public bool IsPasswordValid(Attendee attendee, string plainPassword)
        {
            var hashedPassword = Hash(plainPassword, attendee.Salt);
            return SlowEquals(attendee.PasswordHash, hashedPassword);
        }

        public byte[] GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[256];
            rng.GetBytes(salt);
            return salt;
        }

        public byte[] Hash(string plainText, byte[] salt)
        {
            var hashFunc = new HMACSHA512();
            var plainBytes = System.Text.Encoding.ASCII.GetBytes(plainText);
            var toHash = new byte[plainBytes.Length + salt.Length];
            plainBytes.CopyTo(toHash, 0);
            salt.CopyTo(toHash, plainBytes.Length);
            return hashFunc.ComputeHash(toHash);
        }

        public bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = a.Length ^ b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }

        public async Task RegisterAsync(Attendee attendee)
        {
            var data = AppFactory.Mapper.Value.Map<Database.Entities.Table.Attendee>(attendee);

            var token = new QuickAuthToken
            {
                Email = attendee.EMail,
                Token = Guid.NewGuid().ToString("N")
            };

            var email = new ConfirmRegistrationMessage
            {
                Email = attendee.EMail,
                FullName = attendee.FullName,
                Token = token.Token
            };

            await Task.WhenAll(
                DataFactory.AttendeeService.Value.InsertAsync(data),
                AppFactory.QuickAuthTokenService.Value.AddQuickAuthTokenAsync(token),
                NotificationFactory.AttendeeNotificationService.Value.SendRegistrationConfirmationEmailAsync(email)
            );
        }

        public async Task UpdateProfileAsync(Attendee attendee)
        {
            var data = AppFactory.Mapper.Value.Map<Database.Entities.Table.Attendee>(attendee);
            data.ETag = "*";

            await DataFactory.AttendeeService.Value.ReplaceAsync(data);
        }

        public async Task<RegistrationConfirmationResult> ConfirmRegistrationByTokenAsync(string token)
        {
            var authToken = await DataFactory.QuickAuthTokenService.Value.GetByKeysAsync(Configuration.Year, token);

            if (authToken == null)
            {
                return RegistrationConfirmationResult.TokenIsInvalid;
            }

            if (authToken.IsUsed)
            {
                return RegistrationConfirmationResult.TokenIsUsed;
            }

            authToken.IsUsed = true;

            var attendee = await DataFactory.AttendeeService.Value.GetByKeysAsync(Configuration.Year, authToken.Email);

            attendee.IsConfirmed = true;

            await Task.WhenAll(
                DataFactory.QuickAuthTokenService.Value.ReplaceAsync(authToken),
                DataFactory.AttendeeService.Value.ReplaceAsync(attendee));

            return RegistrationConfirmationResult.Confirmed;
        }
    }
}
