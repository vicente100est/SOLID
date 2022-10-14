using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace D
{
    public class Program
    {
        static async void Main(string[] args)
        {
            string origin = "Origen de la wea";
            string dbPath = "Path de la wea";

            IInfo info = new InfoByRequest(origin);

            Monitor monitor = new Monitor(origin, info);
            await monitor.Show();

            FileDB fileDB = new FileDB(dbPath, origin, info);
            await fileDB.Save();
        }
    }

    public class Monitor
    {
        private string _origin;
        private IInfo _info;
        public Monitor(string origin, IInfo info)
        {
            this._origin = origin;
            this._info = info;
        }
        public async Task Show()
        {
            //InfoByFile info = new InfoByFile(_origin);
            var posts = await _info.Get();
            foreach (var post in posts)
                Console.WriteLine(post.Title);
        }
    }

    public class FileDB
    {
        private string _path;
        private string _origin;
        private IInfo _info;

        public FileDB(string path, string origin, IInfo info)
        {
            this._path = path;
            this._origin = origin;
            this._info = info;
        }

        public async Task Save()
        {
            //InfoByFile info = new InfoByFile(_origin);
            var posts = await _info.Get();
            string json = JsonSerializer.Serialize(posts);
            await File.WriteAllTextAsync(_path, json);
        }
    }

    public class InfoByFile : IInfo
    {
        private string _path;
        public InfoByFile(string path)
        {
            this._path = path;
        }

        public async Task<IEnumerable<Post>> Get()
        {
            var contentStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
            IEnumerable<Post> post =
                await JsonSerializer.DeserializeAsync<IEnumerable<Post>>(contentStream);
            return post;
        }
    }

    public class InfoByRequest : IInfo
    {
        private string _url;
        public InfoByRequest(string url)
        {
            this._url = url;
        }

        public async Task<IEnumerable<Post>> Get()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_url);

            var stream = await response.Content.ReadAsStreamAsync();

            List<Post> posts = await JsonSerializer.DeserializeAsync<List<Post>>(stream);

            return posts;
        }
    }

    public interface IInfo
    {
        public Task<IEnumerable<Post>> Get();
    }

    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
