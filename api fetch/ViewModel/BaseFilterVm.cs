namespace api_fetch.ViewModel;

public class BaseFilterVm
{
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 500;
}