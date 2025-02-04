public static class GameEvents
{
    public static event System.Action OnTurnStarted;
    public static event System.Action OnTurnEnded; 
    public static event System.Action<CardHandler[]> OnBoardStateChanged;
    public static void TurnStarted() => OnTurnStarted?.Invoke();
    public static void TurnEnded() => OnTurnEnded?.Invoke();
    public static void BoardStateChanged(CardHandler[] cards) => OnBoardStateChanged?.Invoke(cards);
}