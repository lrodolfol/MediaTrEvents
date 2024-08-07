namespace MediaTr.Manager.Model.Entities;

public struct User(string Name, string Email)
{
    public string Name { get; set; } = Name;
    public string Email { get; set; } = Email;
}
