using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;

namespace Aula3.Models
{
    public class DocFiles
    {
        // this method gets all filenames from folder
        // instead of getting them from a DB or other storage kind
        public List<FileViewModel> GetFiles(IHostEnvironment e)
        {
            List<FileViewModel> list = new();

            // get all info from "Documents" folder
            DirectoryInfo dirInfo = new(
                Path.Combine(e.ContentRootPath, "wwwroot/Documents"));

            // use the info from folder to get the filenames
            foreach (var item in dirInfo.GetFiles())
            {
                list.Add(new FileViewModel
                {
                    Name = item.Name,
                    Size = item.Length
                });
            }
            return list;
        }
    }
}
