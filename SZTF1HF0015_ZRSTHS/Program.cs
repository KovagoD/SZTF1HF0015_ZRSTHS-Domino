using System;

namespace SZTF1HF0015_ZRSTHS
{
    class Domino
    {
        public int[] sides = new int[2];
        public bool isInUse = false;
        public Domino(int[] sides)
        {
            this.sides = sides;
            isInUse = false;
        }
        public void Rotate()
        {
            int tmp = sides[0];
            sides[0] = sides[1];
            sides[1] = tmp;
        }
    }

    internal class Program
    {
        static Domino[] dominos;
        static void Main(string[] args)
        {
            dominos = Input(int.Parse(Console.ReadLine()));
            if (PlaceDomino()) { Console.WriteLine("Y"); }
            else { Console.WriteLine("N"); }
        }

        static Domino[] Input(int dominoCount)
        {
            Domino[] dominos = new Domino[dominoCount];

            for (int i = 0; i < dominoCount; i++)
            {
                string[] tmp = Console.ReadLine().Split('|');
                dominos[i] = new Domino(new int[] { int.Parse(tmp[0]), int.Parse(tmp[1]) });
            }
            return dominos;
        }

        static bool PlaceDomino()
        {
            for (int i = 0; i < dominos.Length; i++)
            {
                dominos[i].isInUse = true;
                if (PlaceDomino(i)) { return true; }

                for (int j = 0; j < dominos.Length; j++)
                {
                    dominos[j].isInUse = false;
                }
            }
            return false;
        }

        static bool PlaceDomino(int previousDomino)
        {
            if (IsFinished()) { return true; }

            for (int i = 0; i < dominos.Length; i++)
            {
                if (!dominos[i].isInUse)
                {
                    if (dominos[i].sides[0] == dominos[previousDomino].sides[1])
                    {
                        dominos[i].isInUse = true;
                        return PlaceDomino(i);
                    }
                    else
                    {
                        if (dominos[i].sides[1] == dominos[previousDomino].sides[1])
                        {
                            dominos[i].Rotate();
                            dominos[i].isInUse = true;
                            return PlaceDomino(i);
                        }
                    }
                }
            }
            return false;
        }

        static bool IsFinished()
        {
            bool isFinsihed = true;
            for (int i = 0; i < dominos.Length; i++)
            {
                if (!dominos[i].isInUse) { isFinsihed = false; }
            }
            return isFinsihed;
        }
    }
}
