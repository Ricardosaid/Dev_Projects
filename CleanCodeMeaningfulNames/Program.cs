
var flaggedCellResult = GetFlaggedCells([
    new Cell(),
    new Cell()
]);

Console.WriteLine(flaggedCellResult.Count);
return;


List<Cell> GetFlaggedCells(List<Cell> gameBoard)
{
    return gameBoard.Where(cell => cell.IsFlagged()).ToList();
    // when is static method
    return gameBoard.Where(_ => Cell.IsFlaggedStatic()).ToList();
}
internal class Cell
{
    public bool IsFlagged()
    {
        return true;
    }
    
    public static bool IsFlaggedStatic()
    {
        return true;
    }
}