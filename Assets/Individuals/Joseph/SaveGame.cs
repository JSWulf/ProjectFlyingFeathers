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

        var l = File.ReadAllLines(f)[0];

        //var r = 


        return 0;
    }
}

