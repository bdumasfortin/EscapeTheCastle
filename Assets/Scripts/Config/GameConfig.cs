public sealed class GameConfig
{
    private static GameConfig mInstance;
    public static GameConfig Instance 
    { 
        get 
        {
            return mInstance ??= new GameConfig();
        } 
    }
}
