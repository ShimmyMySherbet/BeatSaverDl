using Microsoft.Win32;
using System.IO;

namespace BeatSaverDl
{
    public static class RegistryManager
    {
        public static void Register(string protocal, string appName, string processPath, string commandFormat = "\"%1\"", string icon = "%0,1")
        {
            var prot = Registry.ClassesRoot.CreateSubKey(protocal);
            prot.SetValue(null, $"URL:{appName}");
            prot.SetValue("URL Protocol", "");

            if (!string.IsNullOrEmpty(icon))
            {
                if (icon.Contains("%0"))
                {
                    var procName = Path.GetFileName(processPath);
                    icon = icon.Replace("%0", procName);
                }
                if (!icon.Contains(","))
                {
                    icon = icon + ",1";
                }
                var defIcon = prot.CreateSubKey("DefaultIcon");
                defIcon.SetValue(null, icon);
            }
            var shell = prot.CreateSubKey("shell");
            var open = shell.CreateSubKey("open");
            var command = open.CreateSubKey("command");
            command.SetValue(null, $"\"{processPath.Replace("\"", "")}\"{(string.IsNullOrWhiteSpace(commandFormat) ? "" : " " + commandFormat)}");
        }
    }
}