using Common;

namespace ClientApi.Common;

public class ReportService : IReportService
{
    private readonly IReportRepostory _reportRepostory;

    public ReportService(IReportRepostory reportRepostory)
    {
        _reportRepostory = reportRepostory;
    }
    public async Task<string> Generate(int userId, ReportModel reportModel)
    {        
        var id  = await _reportRepostory.GetData(userId);
        var result = $"User Id {userId} run this report {reportModel.Name} Guid {id}";
        Console.WriteLine(result);
        return result;
    }
}
