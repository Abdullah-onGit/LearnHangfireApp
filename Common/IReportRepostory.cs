namespace Common;

public interface IReportRepostory
{
    Task<Guid> GetData(int UserId);
}
public class ReportRepostory : IReportRepostory
{
    public async Task<Guid> GetData(int userId)
    {
        var a = userId * 5;
        await Task.Delay(1000);
        return await Task.FromResult(Guid.NewGuid());
    }
}