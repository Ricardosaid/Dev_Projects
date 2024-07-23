namespace LambdaAdvance;

public class Singleton
{
    private static Singleton _instance = null;

    private static readonly object Padlock = new object();
    
    
    private Singleton()
    {
        
    }
    
    public static Singleton Instance
    {
        get
        {
            lock (Padlock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }

            return _instance;
        }
    }
}