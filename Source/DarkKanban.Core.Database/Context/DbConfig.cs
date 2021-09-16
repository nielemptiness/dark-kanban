namespace DarkKanban.Core.Database.Context
{
    public class DbConfig
    {
        public int PoolSize { get; set; } = 2;
        public string ConnectionString { get; set; }
    }
}