using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DevToolsNet.GoogleServices;

namespace DevToolsNet.zzzTester
{
    internal class TestGoogle
    {
        public async static void Drive()
        {
            try
            {
                GoogleDriveService gds = new GoogleDriveService();

                
                /*var dirs = await gds.ListRootFolders();
                foreach (var dir in dirs)
                {
                    Console.WriteLine($"{dir.Name} ({dir.Id})");
                    var subDirs = await gds.ListFoldersInFolder(dir.Id);
                    foreach (var item in subDirs)
                    {
                        Console.WriteLine($"  - {item.Name} ({item.Id})");
                    }
                }*/


                var files = await gds.ListFiles("10pwKJqexLZ2oV6otK-4vohG-7CZdNRgp");
                //var files = await gds.ListFiles();
                
                foreach (var file in files)
                {
                    Console.WriteLine(file.Name);
                }

                //var res2 = await gds.UploadFile("e:\\cosshair1.cfg", "*/*");
                //10pwKJqexLZ2oV6otK-4vohG-7CZdNRgp
                var res = await gds.CreateFolder("TestFolder");
                if(res == null)
                {
                    Console.WriteLine("Carpeta creada: " + res);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
