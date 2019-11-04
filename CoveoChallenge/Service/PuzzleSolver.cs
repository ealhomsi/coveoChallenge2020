using System.Collections.Generic;
using System.Linq;

namespace CoveoChallenge.Services
{
    public static class PuzzleSolver
    {
        public readonly static int[] X_MOVES = { 1, -1, 1, -1, 0, 0, 1, -1 };
        public readonly static int[] Y_MOVES = { 1, 1, -1, -1, 1, -1, 0, 0 };
        public readonly static int[] CHARACTER_SIZES = { 12, 11, 9, 9 };

        public readonly static char[] CHARACTERS = { 'O', 'E', 'C', 'V' };
        public readonly static Dictionary<char, int> CHAR_MAP = new Dictionary<char, int>()
        {
            { 'O', 0 },
            { 'E', 1 },
            { 'C', 2 },
            { 'V', 3 }
        };

        public static string Solve(List<List<char>> Data)
        {
            int height = Data.Count;
            if (height == 0)
                return "";
            int width = Data[0].Count;

            // step1 iterate over all the matrix
            string res = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (Data[i][j] == 'X')
                    {
                        // run flood fill to box the shape
                        int[] boundingBox = { height + 1, -1, width + 1, -1, };
                        int totalMarked = FloodFill(i, j, Data, width, height, boundingBox);

                        // Try characters in this order O->12, E->11, C->9, V->9
                        string current = TryMatch(Data, boundingBox, totalMarked);
                        if (current != null)
                        {
                            res += current;
                        }

                        // clear all the V
                        ClearVinBox(Data, boundingBox);
                    }
                }
            }
            return res;
        }

        private static void ClearVinBox(List<List<char>> data, int[] boundingBox)
        {
            for (int i = boundingBox[0]; i <= boundingBox[1]; i++)
            {
                for (int j = boundingBox[2]; j <= boundingBox[3]; j++)
                {
                    if (data[i][j] == 'V')
                    {
                        data[i][j] = '.';
                    }
                }
            }
        }

        public static string TryMatch(List<List<char>> data, int[] boundingBox, int cellsLeft)
        {
            // we cannot construct more characters
            if (cellsLeft < 9)
                return null;

            // BackTrack and try all possible characters
            for (int i = boundingBox[0]; i <= boundingBox[1]; i++)
            {
                for (int j = boundingBox[2]; j <= boundingBox[3]; j++)
                {
                    if (data[i][j] == 'V')
                    {
                        for (int character = 0; character < 4; character++)
                        {
                            if (cellsLeft < CHARACTER_SIZES[character])
                                continue;

                            for (int orientation = 0; orientation < 3; orientation++)
                            {
                                List<List<char>> clone = data.Select(list => list.Select(item => item).ToList()).ToList();
                                if (MatchChar(clone, character, orientation, i, j, boundingBox))
                                {
                                    string rest = TryMatch(clone, boundingBox, cellsLeft - CHARACTER_SIZES[character]);
                                    if (rest != null)
                                        return CHARACTERS[character] + rest;
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }

        public static bool MatchChar(List<List<char>> data, int c, int o, int startX, int startY, int[] boundingBox)
        {
            int[,] moves = MoveGenerator.GenerateCharLayout(c, o);

            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int newX = startX + moves[i, 0];
                int newY = startY + moves[i, 1];

                if (!BoundPoint(newX, newY, boundingBox) || data[newX][newY] != 'V')
                {
                    return false;
                }

                data[newX][newY] = '.';
            }
            return true;
        }

        public static bool BoundPoint(int newX, int newY, int[] boundingBox)
        {
            if (newX >= boundingBox[0] && newX <= boundingBox[1] && newY >= boundingBox[2] && newY <= boundingBox[3])
            {
                return true;
            }
            return false;
        }



        public static int FloodFill(int startX, int startY, List<List<char>> data, int width, int height, int[] boundingBox)
        {
            // mark the position as visited and explore neighbors
            data[startX][startY] = 'V';
            boundingBox = UpdateBox(new int[4] { startX, startX, startY, startY }, boundingBox);

            int totalMarked = 1;
            for (int i = 0; i < X_MOVES.Length; i++)
            {
                int newX = startX + X_MOVES[i];
                int newY = startY + Y_MOVES[i];

                if (newX >= 0 && newY >= 0 && newX < height && newY < width && data[newX][newY] == 'X')
                {
                    totalMarked += FloodFill(newX, newY, data, width, height, boundingBox);
                }
            }

            return totalMarked;
        }

        public static int[] UpdateBox(int[] b1, int[] b2)
        {
            return new int[4] { Min(b1[0], b2[0]), Max(b1[1], b2[1]), Min(b1[2], b2[2]), Max(b1[3], b2[3]) };
        }

        public static int Min(int x, int y)
        {
            if (x < y)
                return x;
            return y;
        }

        public static int Max(int x, int y)
        {
            if (y > x)
                return y;
            return x;
        }
    }
}
