namespace ATWebAPI
{
    public static class AppConfig
    {
        public static string ConnectionString { get; set; }
        public static int MaxItemCount { get; set; }
        public static string Issuer { get; set; }
        public static string Audience { get; set; }
        public static string Key { get; set; }

        public static void LoadConfiguration(IConfiguration configuration)
        {
            Issuer = configuration["Jwt:Issuer"];
            Audience = configuration["Jwt:Audience"];
            Key=configuration["Jwt:Key"];
        }
    }
}
