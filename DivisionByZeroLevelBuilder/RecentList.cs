using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionByZeroLevelBuilder
{
    public class RecentFile
    {
        public string fileName;
        public string levelName;
        public string fullPath;
    }

    public class RecentList
    {
        private static RecentList instance;

        private const string FILE_RECENT = "recent";
        private const int MAX_RECENT = 5;

        private List<RecentFile> recentFiles = new List<RecentFile>(MAX_RECENT);
        // path, index
        private Dictionary<String, RecentFile> set = new Dictionary<String, RecentFile>();

        private RecentList() { }

        public static RecentList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecentList();
                }
                return instance;
            }
        }

        public void Load(string folder)
        {
            string file = folder + "\\" + FILE_RECENT;
            if (!System.IO.File.Exists(file))
            {
                return;
            }

            using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
            {
                string line = "";
                for (int i = 0; i < MAX_RECENT && (line = reader.ReadLine()) != null; i++) 
                {
                    line = line.Trim();
                    if (line.Length == 0)
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        string[] tokens = line.Split('|');
                        if (tokens.Length != 2)
                        {
                            // something is wrong... we are only expecting two tokens
                            // crash quietly...
                            return;
                        }
                        else
                        {
                            AddRecent(tokens[0], tokens[1]);
                        }
                    }
                }
            }
        }

        public void Save(string folder)
        {
            string file = folder + "\\" + FILE_RECENT;
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file))
            {
                foreach (RecentFile f in recentFiles)
                {
                    writer.WriteLine("{0}|{1}", f.fullPath, f.levelName);
                }
            }
        }

        public List<RecentFile> GetRecentFiles()
        {
            return recentFiles;
        }

        public void AddRecent(string path, string levelName)
        {
            RecentFile val;
            if (set.TryGetValue(path, out val))
            {
                recentFiles.Remove(val);
            }

            string name = levelName;
            RecentFile recent = new RecentFile();
            recent.fullPath = path;
            recent.levelName = name;

            int start = path.LastIndexOf('\\');
            int end = path.LastIndexOf('.');
            string fileName = path.Substring(start + 1, (end - start) - 1);
            recent.fileName = fileName;

            recentFiles.Add(recent);
            if (!set.ContainsKey(path))
            {
                set.Add(path, recent);
                if (recentFiles.Count > MAX_RECENT)
                {
                    set.Remove(recentFiles[0].fullPath);
                    recentFiles.RemoveAt(0);
                }
            }
            else
            {
                set[path] = recent;
            }
        }
    }
}
