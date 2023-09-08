namespace UserCRUDApi.Domain.Dtos;

public class UserGetPagination
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 1;
}