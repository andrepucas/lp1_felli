namespace Felli
{
    public enum State
    {
        // Playable positions.
        B,
        W,
        Empty,

        // Board limits and paths.
        Down,
        Side,
        Left,
        Right,
        Blocked
    }
}