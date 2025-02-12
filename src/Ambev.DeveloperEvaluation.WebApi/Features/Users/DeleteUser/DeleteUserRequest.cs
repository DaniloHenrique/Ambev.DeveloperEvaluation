namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class DeleteUserRequest
{
    /// <summary>
    /// Create instance of <see cref="DeleteUserRequest"/>
    /// </summary>
    /// <param name="id"></param>
    public DeleteUserRequest(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; }
}
