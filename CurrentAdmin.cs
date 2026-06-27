namespace ScooterAdmin;

/// <summary>
/// Данные администратора, который сейчас вошёл в систему.
/// Это простой общий класс, чтобы не передавать ФИО и ID между формами вручную.
/// </summary>
public static class CurrentAdmin
{
    public static int UserID { get; set; }
    public static string Login { get; set; } = "";
    public static string FullName { get; set; } = "";
    public static string Role { get; set; } = "";

    public static void Clear()
    {
        UserID = 0;
        Login = "";
        FullName = "";
        Role = "";
    }
}
