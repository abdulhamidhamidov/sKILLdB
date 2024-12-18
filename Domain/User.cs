namespace DefaultNamespace;

public class User
{
    public int UserId { get; set; }  // Primary Key
    public string FullName { get; set; }  // Full name of the user
    public string Email { get; set; }  // Email address of the user
    public string Phone { get; set; }  // Phone number of the user
    public string City { get; set; }  // City where the user lives
    public DateTime CreatedAt { get; set; }  // Registration date


}