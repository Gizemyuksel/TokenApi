using TokenApi.Base;

namespace TokenApi.Data;

public class Account : BaseModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public DateTime LastActivity { get; set; }
}
