using System;

namespace MinhasFinancas.Settings.DbSettings;

public class MySqlSettings
{
    public static readonly string SESSION_NAME = "MysqlSettings";
    public string ConnectionString { get; set; }
}
