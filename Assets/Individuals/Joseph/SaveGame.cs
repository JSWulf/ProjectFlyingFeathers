using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


public static class SaveGame
{
    private static int s_loadPoints;

    public static int LoadPoints
    {
        get
        {
            return ReadFile();
        }

        private set => s_loadPoints = value;
    }

    private static int ReadFile()
    {
        var f = MainMenuController.SaveFile;

        if (File.Exists(f))
        {
            return 0;
        }
        var l = File.ReadAllLines(f)[0];

        var r = DESEncryption.TryDecrypt(l, "pwd");

        int p = 0;

        try
        {
            p = Convert.ToInt32(r);
        }
        catch (Exception)
        {
            //do nothing
        }
        

        return p;
    }

    public static void Save(int pts)
    {
        var s = DESEncryption.Encrypt(pts.ToString(), "pwd");

        File.WriteAllText(MainMenuController.SaveFile, s);
    }
}

