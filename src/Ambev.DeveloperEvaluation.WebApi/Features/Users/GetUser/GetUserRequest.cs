namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetUserRequest
{
    public GetUserRequest() { }
    public GetUserRequest(Guid id)
    {
        Id = id;
    }
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
