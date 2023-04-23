using YoutubeExplode;

namespace Module18;

public class GetVideoInfoCommand : ICommand
{
    private readonly string _videoInfo;

    
    public GetVideoInfoCommand(string videoInfo)
    {
        _videoInfo = videoInfo;
    }

    public async Task ExecuteAsync()
    {
        var youtube = new YoutubeClient();
        var video = await youtube.Videos.GetAsync(_videoInfo);

        Console.WriteLine($"Название видео: {video.Title}");
        Console.WriteLine($"Описание видео: {video.Description}");
    }
}
