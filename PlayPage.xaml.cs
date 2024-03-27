using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiOnline_launcher_dev_ver
{
    /// <summary>
    /// Логика взаимодействия для PlayPage.xaml
    /// </summary>
    public partial class PlayPage : Page
    {
        public class Root
        {
            public string game_version { get; set; }
        }
        public const string Version_File = @"C:\bionline\launcher\BiOnline\BuildVersion.txt";

        public static async Task NeedUpdateBuild()
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://bionline-server.ru/?game_version"))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "application/json");

                        var response = await httpClient.SendAsync(request);

                        var a = await response.Content.ReadAsStringAsync();
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(a);
                        config.ActualVersion = myDeserializedClass.game_version;
                        using (StreamReader sr = new StreamReader(Version_File))
                        {
                            string line = sr.ReadLine();
                            
                            if (line == myDeserializedClass.game_version)
                                return;
                            else
                            {
                                await DownloadBuild();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static async Task DownloadBuild()
        {
            if (File.Exists(config.archiveBuildPath))
                File.Delete(config.archiveBuildPath);
            if (Directory.Exists(config.BuildPath))
                Directory.Delete(config.BuildPath, true);

            byte[] data;
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(config.BuildLink))
                {
                    using (HttpContent content = response.Content)
                    {
                        data = await content.ReadAsByteArrayAsync();
                        using (FileStream file = File.Create(@"C:\bionline\1.zip"))
                        {
                            file.Write(data, 0, data.Length);
                        }
                    }
                }
            }
            ZipFile.ExtractToDirectory(config.archiveBuildPath, config.BuildPath);
            if (File.Exists(config.archiveBuildPath))
                File.Delete(config.archiveBuildPath);
        }
        public PlayPage()
        {
            InitializeComponent();
        }

        public static async Task UpdateModsConfig()
        {
            try
            {
                if (File.Exists(config.AppDataPath))
                    File.Delete(config.AppDataPath);
                byte[] data;
                using (var client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(config.ModsConfigLink))
                    {
                        using (HttpContent content = response.Content)
                        {
                            data = await content.ReadAsByteArrayAsync();

                            using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                                        fileStream = new FileStream(config.AppDataPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true)
                                        {

                                        })
                            {
                                await contentStream.CopyToAsync(fileStream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); };
        }
        private async void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await UpdateModsConfig();
            if (config.IsPirate == false)
                Process.Start(config.DefaultStartGame);
            else
            {
                await NeedUpdateBuild();
                using (StreamWriter sw = new StreamWriter(Version_File))
                {
                    sw.Write(config.ActualVersion);
                }
                Process.Start(config.DefaultStartGame);
            }
        }

        private void SettingsGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
           w682372 w682372 = new w682372();
           w682372.Show();
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
