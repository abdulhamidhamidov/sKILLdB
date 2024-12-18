namespace DefaultNamespace;

public class Skill
{
    public int SkillId { get; set; }  // Primary Key
    public int UserId { get; set; }  // Foreign Key (User who offers the skill)
    public string Title { get; set; }  // Name of the skill or service
    public string Description { get; set; }  // Description of the skill/service
    public DateTime CreatedAt { get; set; }  // Date when the skill was added
}