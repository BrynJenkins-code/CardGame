public static class GameEvents
{
    public delegate void BoardStateChangeHandler(CardHandler[] cards);
    public static event BoardStateChangeHandler OnBoardStateChanged;

    public static void BoardStateChanged(CardHandler[] cards)
    {
        OnBoardStateChanged?.Invoke(cards);
    }
}