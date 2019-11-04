using System;

namespace CoveoChallenge.Services
{
    public static class MoveGenerator
    {
        public static int[,] GenerateCharLayout(int c, int o)
        {
            switch (c)
            {
                case 0:
                    return GenerateOLayout(o);
                case 1:
                    return GenerateELayout(o);
                case 2:
                    return GenerateCLayout(o);
                case 3:
                    return GenerateVLayout(o);

                default:
                    throw new Exception();
            }
        }

        private static int[,] GenerateOLayout(int o)
        {
            switch (o)
            {
                case 0:
                    return GenerateOLayout0();
                case 1:
                    return GenerateOLayout90();
                case 2:
                    return GenerateOLayout180();
                case 3:
                    return GenerateOLayout270();

                default:
                    throw new Exception();
            }
        }

        private static int[,] GenerateOLayout0()
        {
            return new int[,]
            {
                { 0, 0},
                { 1, 0},
                { 2 ,0},
                { 3, 0},
                { 4, 0},
                { 0, 2},
                { 1, 2},
                { 2 ,2},
                { 3, 2},
                { 4, 2},
                { 0, 1},
                { 4, 1},
            };
        }

        private static int[,] GenerateOLayout90()
        {
            return new int[,]
            {
                { 0, 0},
                { 0, 1},
                { 0, 2},
                { 0, 3},
                { 0, 4},
                { -2, 0},
                { -2, 1},
                { -2, 2},
                { -2, 3},
                { -2, 4},
                { -1, 0},
                { -1, 4}
            };
        }

        private static int[,] GenerateOLayout180()
        {
            return new int[,]
            {
                { 0, 0},
                { -1, 0},
                { -2, 0},
                { -3, 0},
                { -4, 0},
                { 0, -2},
                { -1, -2},
                { -2, -2},
                { -3, -2},
                { -4, -2},
                { 0, -1},
                { -4, -1}
            };
        }

        private static int[,] GenerateOLayout270()
        {
            return new int[,]
            {
                { 0, 0},
                { 0, -1},
                { 0, -2},
                { 0, -3},
                { 0, -4},
                { 2, 0},
                { 2, -1},
                { 2, -2},
                { 2, -3},
                { 2, -4},
                { 1, 0},
                { 1, -4}
            };
        }

        private static int[,] GenerateELayout(int o)
        {
            switch (o)
            {
                case 0:
                    return GenerateELayout0();
                case 1:
                    return GenerateELayout90();
                case 2:
                    return GenerateELayout180();
                case 3:
                    return GenerateELayout270();

                default:
                    throw new Exception();
            }
        }

        private static int[,] GenerateELayout0()
        {
            return new int[,]
            {
                { 0, 0},
                { 0, 1},
                { 0, 2},
                { 1, 0},
                { 2, 0},
                { 2, 1},
                { 2, 2},
                { 3, 0},
                { 4, 0},
                { 4, 1},
                { 4, 2},
            };
        }

        private static int[,] GenerateELayout90()
        {
            return new int[,]
            {
                { 0, 0},
                { -1, 0},
                { -2, 0},
                { 0, 1},
                { 0, 2},
                { -1, 2},
                { -2, 2},
                { 0, 3},
                { 0, 4},
                { -1, 4},
                { -2, 4}
            };
        }

        private static int[,] GenerateELayout180()
        {
            return new int[,]
            {
                { 0, 0},
                { 0, -1},
                { 0, -2},
                { -1, 0},
                { -2, 0},
                { -2, -1},
                { -2, -2},
                { -3, 0},
                { -4, 0},
                { -4, -1},
                { -4, -2}
            };
        }

        private static int[,] GenerateELayout270()
        {
            return new int[,]
            {
                { 0, 0},
                { 1, 0},
                { 2, 0},
                { 0, -1},
                { 0, -2},
                { 1, -2},
                { 2, -2},
                { 0, -3},
                { 0, -4},
                { 1, -4},
                { 2, -4},
            };
        }

        private static int[,] GenerateCLayout(int o)
        {
            switch (o)
            {
                case 0:
                    return GenerateCLayout0();
                case 1:
                    return GenerateCLayout90();
                case 2:
                    return GenerateCLayout180();
                case 3:
                    return GenerateCLayout270();

                default:
                    throw new Exception();
            }
        }

        private static int[,] GenerateCLayout0()
        {
            return new int[,]
             {
                { 0, 0},
                { 1, 0},
                { 2 ,0},
                { 3, 0},
                { 4, 0},
                { 0, 2},
                { 4, 2},
                { 0, 1},
                { 4, 1},
             };
        }

        private static int[,] GenerateCLayout90()
        {
            return new int[,]
             {
                { 0, 0},
                { 0, 1},
                { 0, 2},
                { 0, 3},
                { 0, 4},
                { -2, 0},
                { -2, 4},
                { -1, 0},
                { -1, 4}
             };
        }

        private static int[,] GenerateCLayout180()
        {
            return new int[,]
            {
                { 0, 0},
                { -1, 0},
                { -2, 0},
                { -3, 0},
                { -4, 0},
                { 0, -2},
                { -4, -2},
                { 0, -1},
                { -4, -1}
            };
        }
        private static int[,] GenerateCLayout270()
        {
            return new int[,]
            {
                { 0, 0},
                { 0, -1},
                { 0, -2},
                { 0, -3},
                { 0, -4},
                { 2, 0},
                { 2, -4},
                { 1, 0},
                { 1, -4}
            };
        }


        private static int[,] GenerateVLayout(int o)
        {
            switch (o)
            {
                case 0:
                    return GenerateVLayout0();
                case 1:
                    return GenerateVLayout90();
                case 2:
                    return GenerateVLayout180();
                case 3:
                    return GenerateVLayout270();

                default:
                    throw new Exception();
            }
        }

        private static int[,] GenerateVLayout0()
        {
            return new int[,]
            {
                { 0, 0},
                { 1, 0},
                { 2 ,0},
                { 3, 0},
                { 0, 2},
                { 1, 2},
                { 2 ,2},
                { 3, 2},
                { 4, 1},
            };
        }

        private static int[,] GenerateVLayout90()
        {
            return new int[,]
            {
                { 0, 0},
                { 0, 1},
                { 0, 2},
                { 0, 3},
                { -2, 0},
                { -2, 1},
                { -2, 2},
                { -2, 3},
                { -1, 4}
            };
        }

        private static int[,] GenerateVLayout180()
        {
            return new int[,]
            {
                { 0, 0},
                { -1, 0},
                { -2, 0},
                { -3, 0},
                { 0, -2},
                { -1, -2},
                { -2, -2},
                { -3, -2},
                { -4, -1}
            };
        }

        private static int[,] GenerateVLayout270()
        {
            return new int[,]
            {
                { 0, 0},
                { 0, -1},
                { 0, -2},
                { 0, -3},
                { 2, 0},
                { 2, -1},
                { 2, -2},
                { 2, -3},
                { 1, -4}
            };
        }
    }
}
