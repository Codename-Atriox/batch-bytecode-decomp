using System.Diagnostics;

namespace bytecode_decomp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            // get folder of bytecodes
            string target_folder = "C:\\Users\\Joe bingle\\Downloads\\HASHING\\bytecodes";

            // get destination folder
            string dest_folder = "C:\\Users\\Joe bingle\\Downloads\\HASHING\\decompiled";

            // get path of decompiler tool
            string decomp_tool_path = "C:\\Users\\Joe bingle\\Downloads\\dxc_2023_08_14\\bin\\x64\\dxc.exe";

            // iterate through all bytecode files
            foreach (string file in Directory.GetFiles(target_folder)){

                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = decomp_tool_path;
                p.StartInfo.Arguments = "-dumpbin \"" + file + "\"";
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                File.WriteAllText(dest_folder + "\\" + Path.GetFileNameWithoutExtension(file) + ".txt", output);
            }

        }
    }
}