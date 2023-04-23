using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Module18;

public class DownloadVideoCommand : ICommand, IDuplicatedFileChecker
{
    private readonly string _url;
    private readonly string _path;
    private readonly string _extension = ".mp4";

    public DownloadVideoCommand(string url)
    {
        _url = url;
        _path = @"C:\Downloads\";
    }

    public DownloadVideoCommand(string url, string path)
    {
        _url = url;
        _path = path;
    }

    public async Task ExecuteAsync()
    {
        var youtube = new YoutubeClient();
        var video = await youtube.Videos.GetAsync(_url);

        Console.WriteLine($"Скачиваем ваше видео : {video.Title}");

        string newName = HandleFileDuplications( _path, video.Title, _extension);
        await youtube.Videos.DownloadAsync(_url, _path + newName);

        Console.WriteLine($"Ваше видео сохранено в {_path}");
    }

    /// <summary>
    /// Метод возвращает название файла - если есть файл с аналогичным названием, 
    /// то он создаст название-копию с инкриментом
    /// </summary>
    /// <param name="path"></param>
    /// <param name="name"></param>
    /// <param name="extension"></param>
    /// <returns></returns>
    public string HandleFileDuplications(string path, string name, string extension)
    {
        if (File.Exists(path + name + extension))
        {
            int counter = 0;
            string newname = $"{name}({counter}){extension}";
            while (File.Exists(path + newname)) 
            {
                counter++;
                newname = $"{name}({counter}){extension}";
            }
            return newname;
        }
        else
            return (name + extension);
    }
}
