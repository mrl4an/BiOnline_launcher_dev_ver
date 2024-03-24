using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiOnline_launcher_dev_ver
{
    internal class config
    {
        public static readonly string ComputerName = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).Split('\\').Last();
        public static readonly string AppDataPath = @"C:\Users\"+ComputerName+@"\AppData\LocalLow\Ludeon Studios\RimWorld by Ludeon Studios";
        public static readonly string DefaultSteamPath = @"C:\Program Files (x86)\Steam\steamapps\common\RimWorld";
        public static string DefaultStartGame = @"C:\Program Files (x86)\Steam\steamapps\common\RimWorld\RimWorldWin64.exe";
        public static bool IsPirate = false;

        public static readonly string BuildLink = @"https://drive.usercontent.google.com/download?id=1WQxJzDchBSiv8WKti5kOUaOkMDK4Sjlo&export=download&confirm=t";
        public static readonly string BuildPath = @"C:\bionline\Rimworld";
        public static readonly string archiveBuildPath = @"C:\bionline\1.zip";
        public static string ActualVersion { get; set; }

    }
}
