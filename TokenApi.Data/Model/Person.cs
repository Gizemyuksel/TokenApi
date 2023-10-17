using TokenApi.Base;

namespace TokenApi.Data;

public class Person : BaseModel
{ 
    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
}
