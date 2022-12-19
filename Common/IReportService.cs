namespace ClientApi.Common;

public interface IReportService
{
    public Task<string> Generate(int userId, ReportModel reportModel);
}
