namespace Felli
{
    /// <summary>
    /// <c>State</c> Enumeration.
    /// Differentiates all board positions. 
    /// </summary>
    public enum State
    {
        // Playable positions.
        B,  // Black;
        W,  // White;
        Empty,

        // Board limits and paths.
        Down,
        Side,
        Left,
        Right,
        Blocked
    }
}