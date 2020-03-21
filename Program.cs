using System;

namespace MatrixMultiplication
{
   class Program
    {
        // MATRİS ÇARPIM KURALLARI:
        // A ve B gibi iki matrisin çarpımlarının tanımlı olabilmesi için; 
        // A matrisinin sütun sayısının B matrisinin satır sayısına eşit olması gerekir.

        // BİLGİ : [x,y] ve [z,t] boyutlarında iki matrisin çarpım matrisi [x,t] boyutunda olur.

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Random random = new Random();

        tryAgain:
            int[,] matrix1 = RandomMatrix(random.Next(1, 10), random.Next(1, 10));
            int[,] matrix2 = RandomMatrix(random.Next(1, 10), random.Next(1, 10));

            // tanımsız matris çarpımı kontrolü
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                Console.WriteLine("Impossible!");
                goto tryAgain;
            }

            WriteMatrix(matrix1);
            WriteMatrix(matrix2);

            int[,] result = MultiplyMatrixes(matrix1, matrix2);
            WriteMatrix(result);
        }

        // rastgele sayılar içeren matris oluşturur
        public static int[,] RandomMatrix(int x, int y)
        {
            int[,] array = new int[x, y];
            Random random = new Random();

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    array[i, j] = random.Next(1, 10);

            return array;
        }

        // matrisi ekrana yazar
        public static void WriteMatrix(int[,] matrix)
        {
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                    if (j == y - 1) Console.WriteLine();
                }

            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }

        // 2 matrisi çarpar
        public static int[,] MultiplyMatrixes(int[,] m1, int[,] m2)
        {
            int x = m1.GetLength(0); // 1.matris satır sayısı
            int y = m1.GetLength(1); // 1.matris sutun ve 2.matris satır sayısı
            int z = m2.GetLength(1); // 2.matris sutun sayisi

            int[,] result = new int[x, z];

            for (int i = 0; i < x; i++)
                for (int j = 0; j < z; j++)
                {
                    result[i, j] = 0;

                    for (int k = 0; k < y; k++)
                        result[i, j] += m1[i, k] * m2[k, j];
                }

            return result;
        }

    }
}
