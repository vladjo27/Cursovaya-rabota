namespace ScooterRental;

/// <summary>
/// Данные пользователя, который сейчас вошёл в приложение.
/// Храним их в одном месте, чтобы не передавать ID, ФИО и контакты между формами вручную.
/// </summary>
public static class CurrentUser
{
    public static int UserID { get; set; }
    public static string Login { get; set; } = "";
    public static string FullName { get; set; } = "";
    public static string Phone { get; set; } = "";
    public static string Email { get; set; } = "";
    public static string Role { get; set; } = "User";

    public static bool IsAdmin => Role == "Admin";

    public static void Clear()
    {
        UserID = 0;
        Login = "";
        FullName = "";
        Phone = "";
        Email = "";
        Role = "User";
    }
}
