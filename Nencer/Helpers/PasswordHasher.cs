namespace Nencer.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 12, true);
        }

        public static bool VerifyHash(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash, true);
        }
    }
}
