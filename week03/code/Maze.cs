/// <summary>
/// Maze navigation logic using coordinate deltas.
/// 
/// Disclaimer: This implementation evolved from a direction-specific approach to a centralized delta-based model.
/// Instead of repeating logic in each movement method, we abstracted the shared behavior into a helper method (`TryMove`)
/// that takes a direction index and coordinate deltas. This mirrors the CSS `::root` pseudo-class concept—centralizing
/// reusable logic to reduce repetition and improve maintainability.
/// 
/// Microsoft CoPilot suggested this refactor, after I initially wrote the direction-specific methods.
/// It was a good learning experience to see how AI can assist in code optimization and learning.
/// 
/// Direction mapping:
/// [0] = left   → deltaX = -1, deltaY =  0
/// [1] = right  → deltaX = +1, deltaY =  0
/// [2] = up     → deltaX =  0, deltaY = -1
/// [3] = down   → deltaX =  0, deltaY = +1
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currentX = 1;
    private int _currentY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Centralized movement logic. Checks if movement is allowed in the given direction,
    /// and updates coordinates using the provided deltas. Throws if blocked.
    /// </summary>
    /// <param name="directionIndex">Index in the direction array: 0=left, 1=right, 2=up, 3=down</param>
    /// <param name="deltaX">Change in X coordinate</param>
    /// <param name="deltaY">Change in Y coordinate</param>
    private void TryMove(int directionIndex, int deltaX, int deltaY)
    {
        var directions = _mazeMap[(_currentX, _currentY)];

        // Check if movement in the specified direction is allowed
        if (!directions[directionIndex])
            throw new InvalidOperationException("Can't go that way!");

        // Update coordinates
        _currentX += deltaX;
        _currentY += deltaY;
    }

    /// <summary>
    /// Attempt to move left. Uses direction index 0 and delta (-1, 0).
    /// </summary>
    public void MoveLeft() => TryMove(0, -1, 0);

    /// <summary>
    /// Attempt to move right. Uses direction index 1 and delta (+1, 0).
    /// </summary>
    public void MoveRight() => TryMove(1, 1, 0);

    /// <summary>
    /// Attempt to move up. Uses direction index 2 and delta (0, -1).
    /// </summary>
    public void MoveUp() => TryMove(2, 0, -1);

    /// <summary>
    /// Attempt to move down. Uses direction index 3 and delta (0, +1).
    /// </summary>
    public void MoveDown() => TryMove(3, 0, 1);

    /// <summary>
    /// Returns the current location in the maze.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currentX}, y={_currentY})";
    }
}
