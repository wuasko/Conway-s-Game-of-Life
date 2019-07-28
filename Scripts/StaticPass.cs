using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticPass {

    private static int speed = 20;
    private static int sizeX = 10;
    private static int sizeY = 10;
    private static int preset = 0;
    private static bool stretched = false;

    public static int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public static int SizeX
    {
        get
        {
            return sizeX;
        }
        set
        {
            sizeX = value;
        }
    }

    public static int SizeY
    {
        get
        {
            return sizeY;
        }
        set
        {
            sizeY = value;
        }
    }
    public static int Preset
    {
        get
        {
            return preset;
        }
        set
        {
            preset = value;
        }
    }
    public static bool Stretched
    {
        get
        {
            return stretched;
        }
        set
        {
            stretched = value;
        }
    }

}
