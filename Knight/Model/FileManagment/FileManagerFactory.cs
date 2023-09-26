using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight.Model.FileManagment
{
    public class FileManagerFactory
    {
        public IFileManager CreateFileManager(string format, string path)
        {
            switch (format)
            {
                case "json":
                    return new JsonManager(path);
                case "dat":
                    return new BinaryManager(path);
                default:
                    throw new ArgumentException("Всё накрылось медным тазом");
            }
        }
    }
}
