namespace SudokuSolver
{
    class SudokuSolver
    {
        private const int GRID_SIZE = 9;

        public static void solveBoard(int[,] board)
        {
            if (solveBoardRec(board))
            {
                Console.WriteLine("\nSolved Successfully!");
            } else
            {
                Console.WriteLine("\nUnsolvable board");
            }
        }

        public static void printBoard(int[,] board)
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                if (row % 3 == 0 && row != 0)
                {
                    Console.WriteLine("-----------");
                }
                for (int column = 0;  column < GRID_SIZE; column++)
                {
                    if (column % 3 == 0 && column != 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write(board[row, column]);
                }
                Console.WriteLine();
            }
        }

        private static bool isNumberInRow(int[,] board, int number, int row)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (board[row, i] == number)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool isNumberInColumn(int[,] board, int number, int column)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (board[i, column] == number)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool isNumberInBox(int[,] board, int number, int row, int column)
        {
            int localBoxRow = row - row % 3;
            int localBoxColumn = column - column % 3;

            for (int i = localBoxRow; i < localBoxRow + 3; i++)
            {
                for (int j = localBoxColumn; j < localBoxColumn + 3; j++)
                {
                    if (board[i, j] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool isValidPlacement(int[,] board, int number, int row, int column)
        {
            return !isNumberInRow(board, number, row) && 
                !isNumberInColumn(board, number, column) && 
                !isNumberInBox(board, number, row, column);
        }

        private static bool solveBoardRec(int[,] board)
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int column = 0;  column < GRID_SIZE; column++)
                {
                    if (board[row, column] == 0)
                    {
                        for (int numberToTry = 1; numberToTry <= GRID_SIZE; numberToTry++)
                        {
                            if (isValidPlacement(board, numberToTry, row, column))
                            {
                                board[row, column] = numberToTry;

                                if (solveBoardRec(board))
                                {
                                    return true;
                                }
                                else
                                {
                                    board[row,column] = 0;
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
    }
}