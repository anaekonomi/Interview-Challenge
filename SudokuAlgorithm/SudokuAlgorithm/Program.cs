namespace SudokuValidatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var goodSudoku = new[]
            {
                new[] {7,8,4,1,5,9,3,2,6},
                new[] {5,3,9,6,7,2,8,4,1},
                new[] {6,1,2,4,3,8,7,5,9},
                new[] {9,2,8,7,1,5,4,6,3},
                new[] {3,5,7,8,4,6,1,9,2},
                new[] {4,6,1,9,2,3,5,8,7},
                new[] {8,7,6,3,9,4,2,1,5},
                new[] {2,4,3,5,6,1,9,7,8},
                new[] {1,9,5,2,8,7,6,3,4}
            };

            var badSudoku = new[]
            {
                new[] {7,8,4,1,5,9,3,2,6},
                new[] {5,3,9,6,7,2,8,4,1},
                new[] {6,1,2,4,3,8,7,5,9},
                new[] {9,2,8,7,1,5,4,6,3},
                new[] {3,5,7,8,4,6,1,9,2},
                new[] {4,6,1,9,2,3,5,8,7},
                new[] {8,7,6,3,9,4,2,1,5},
                new[] {2,4,3,5,6,1,9,7,8},
                new[] {1,9,5,2,8,7,6,4,4} // Error here
            };

            ValidateAndPrint(goodSudoku, "Good Sudoku");
            ValidateAndPrint(badSudoku, "Bad Sudoku");

            Console.ReadLine();
        }

        /// <summary>
        /// Helper to validate a board and print the result
        /// </summary>
        /// <param name="board"></param>
        /// <param name="boardName"></param>
        private static void ValidateAndPrint(int[][] board, string boardName)
        {
            bool isValid = SudokuValidator.IsValid(board);
            Console.WriteLine($"{boardName} is valid: {isValid}");
        }
    }

    /// <summary>
    /// Static class with all validation logic
    /// </summary>
    public static class SudokuValidator
    {
        /// <summary>
        /// Checks board size, rows, columns, blocks
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool IsValid(int[][] board)
        {
            if (!IsValidSize(board))
                return false;

            int n = board.Length;
            int sqrtN = (int)Math.Sqrt(n);

            return Enumerable.Range(0, n).All(i =>
                       IsValidSet(board[i], n) &&
                       IsValidSet(board.Select(row => row[i]), n))
                   && Enumerable.Range(0, sqrtN).All(rowBlock =>
                       Enumerable.Range(0, sqrtN).All(colBlock =>
                           IsValidBlock(board, rowBlock * sqrtN, colBlock * sqrtN, sqrtN, n)));
        }

        /// <summary>
        /// Checks dimension NxN and sqrt of N is integer
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private static bool IsValidSize(int[][] board)
        {
            int n = board.Length;
            return n > 0 && board.All(row => row.Length == n) && Math.Sqrt(n) % 1 == 0;
        }

        /// <summary>
        /// Checks if a set has 1 to N exactly once
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static bool IsValidSet(IEnumerable<int> numbers, int n)
        {
            var set = numbers.ToList();
            return set.Count == n && set.All(x => x >= 1 && x <= n) && set.Distinct().Count() == n;
        }

        /// <summary>
        /// Checks a single small square (block)`1
        /// </summary>
        /// <param name="board"></param>
        /// <param name="startRow"></param>
        /// <param name="startCol"></param>
        /// <param name="blockSize"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static bool IsValidBlock(int[][] board, int startRow, int startCol, int blockSize, int n)
        {
            var block = Enumerable.Range(0, blockSize)
                .SelectMany(r => Enumerable.Range(0, blockSize)
                    .Select(c => board[startRow + r][startCol + c]));

            return IsValidSet(block, n);
        }
    }
}