namespace DefaultNamespace;

public class Request
{
    public int RequestId { get; set; }  // Primary Key
    public int FromUserId { get; set; }  // Foreign Key (User who initiates the request)
    public int ToUserId { get; set; }  // Foreign Key (User who receives the request)
    public int RequestedSkillId { get; set; }  // Foreign Key (Skill requested)
    public int OfferedSkillId { get; set; }  // Foreign Key (Skill offered in exchange)
    public string Status { get; set; }  // Status of the request (e.g., Pending, Accepted, Rejected)
    public DateTime CreatedAt { get; set; }  // Date when the request was created
    public DateTime UpdatedAt { get; set; }  // Date when the request was last updated
 
}