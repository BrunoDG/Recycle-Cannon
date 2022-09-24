using System;
public class MathUtils
{
    public static int GetRandomInt(int min, int max)
    {
        var rand = new Random();
        int index = rand.Next(min, max);
        return index;
    }
}