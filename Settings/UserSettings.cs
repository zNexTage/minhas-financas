using System;

namespace MinhasFinancas.Settings;

public class UserSettings
{
    public static readonly string TOKEN_SESSSION_NAME = "TokenSettings";

    public string TokenKey { get; set; }
}
