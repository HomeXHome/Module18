
namespace Module18;

public class YouTubeInvoker
{
    private readonly ICommand _getVideoCommand;
    private readonly ICommand _downloadVideoCommand;

    public YouTubeInvoker(ICommand getVideoCommand, ICommand downloadVideoCommand)
    {
        _getVideoCommand = getVideoCommand;
        _downloadVideoCommand = downloadVideoCommand;
    }

    public async Task DownloadVideo() { await _downloadVideoCommand.ExecuteAsync(); }

    public async Task GetVideoInfo() { await _getVideoCommand.ExecuteAsync(); }
}
