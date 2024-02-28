using System;

[Serializable]
public class GameData
{
    public string playerName;
    public int unlockedLevels;
}

[Serializable]
public class LevelData
{ 
    public int level;
    public int bulletCount;
    public string levelmode;
    public Vec3Ser targetposition;
}
[Serializable]
public class SettingsData
{
    public float volume;
    public int quality;
    public bool isFullScreen;
}

[Serializable]
public class Vec3Ser
{
    public float x;
    public float y;
    public float z;

    public   Vec3Ser(float x,float y,float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

