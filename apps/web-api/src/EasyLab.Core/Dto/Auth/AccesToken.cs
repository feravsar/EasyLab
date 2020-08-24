namespace EasyLab.Core.Dto.Auth
{
    /// <summary>
    /// Access token that should be used to accessing protected API resources
    /// </summary>
    public sealed class AccessToken
    {
        /// <summary>Token string</summary>
        public string Token { get; }
        
        /// <summary>Access token expiration time in seconds</summary>
        public int ExpiresIn { get; }

        public AccessToken(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
