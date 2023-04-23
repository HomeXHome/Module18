using YoutubeExplode;
using YoutubeExplode.Videos;

namespace Module18;
class Program
{
    static async Task Main(string[] args)
    {
        string videoUrl = "https://youtu.be/UR3Yh9sFD3M";
        string savePath = @"D:\C#\Download\";

        var getVideoInfoCommand = new GetVideoInfoCommand(videoUrl);
        var downloadVideoCommand = new DownloadVideoCommand(videoUrl, savePath);

        var youtubeInvoker = new YouTubeInvoker(getVideoInfoCommand, downloadVideoCommand);

        await youtubeInvoker.GetVideoInfo();
        await youtubeInvoker.DownloadVideo();
    }
}
