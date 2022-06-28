
public class GameStatus
{
    private static EGameStatus _gameStatus = EGameStatus.Menu;

    public static event System.Action<EGameStatus> Changed;

    public static EGameStatus Get()
    {
        return _gameStatus;
    }

    public static void Set(EGameStatus status)
    {
        _gameStatus = status;
        Changed?.Invoke(status);
    }
}

