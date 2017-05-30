using System;

namespace MatrisCarpimi
{
    class Program
    {
        static void Main(string[] args)
        {
            // MATRİS ÇARPIM KURALLARI :
            // A ve B gibi iki matrisin çarpımlarının tanımlı olabilmesi için; 
            // A matrisinin sütun sayısının B matrisinin satır sayısına eşit olması gerekir.

            // BİLGİ : [x,y] ve [z,t] boyutlarında iki matrisin çarpım matrisi [x,t] boyutunda olur.

            int[,] a = new int[100, 100]; // ilk matris (A)
            int[,] b = new int[100, 100]; // ikinci matris (B)
            int[,] c = new int[100, 100]; // ikinci matrisi ters çevirmek için kullanılan ara matris (C)
            int[,] d = new int[100, 100]; // sonuç(çarpım) matrisi
            int i, j, x, y, z, t, k;
            Random rastgele = new Random();

            tekrar:
            Console.Write("\n1.matrisin satir sayisi:"); x = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n1.matrisin sütun sayisi:"); y = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n--------------------------");
            Console.Write("\n2.matrisin satir sayisi:"); z = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n2.matrisin sütun sayisi:"); t = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n");

            if (y != z)
            {
                Console.WriteLine("\n!!!!!!!!  1.Matrisin Sütun Sayısı İle 2.Matrisin Satır Sayısı Aynı Olmalıdır !!!!!!!!\n\n");
                goto tekrar;
            }
            else
            {
                // A matrisini oluştur(rastgele) ve ekrana yaz
                for (i = 0; i < x; i++)
                {
                    for (j = 0; j < y; j++)
                    {
                        a[i, j] = rastgele.Next(1, 10);
                        Console.Write("{0,5}", a[i, j]);
                        if (j == y - 1) Console.Write("\n");
                    }
                }
                Console.WriteLine("\n\n");

                // B matrisini oluştur(rastgele) ve ekrana yaz
                // (B'yi ters çevir C matrisi haline getir)
                for (i = 0; i < z; i++)
                {
                    for (j = 0; j < t; j++)
                    {
                        b[i, j] = rastgele.Next(1, 10);
                        Console.Write("{0,5}", b[i, j]);
                        if (j == t - 1) Console.Write("\n");
                        c[j, i] = b[i, j];
                    }
                }
                Console.WriteLine("\n\n");

                // C matrisini ekrana yaz
                // for (i = 0; i < t; i++)                            
                //     for (j = 0; j < z; j++)
                //     {
                //         Console.Write("{0,5}", c[i, j]);
                //         if (j == z - 1) Console.Write("\n");
                //     }
                // Console.WriteLine("\n\n");

                // SONUCU ÖNCE SIFIRLA
                for (i = 0; i < x; i++)
                    for (j = 0; j < t; j++)
                        d[i, j] = 0;

                // ÇARPIM MATRİSİNİ OLUŞTUR(SONUCU)
                for (i = 0; i < x + z; i++)
                {
                    for (k = 0; k < t + y; k++)
                        for (j = 0; j < t + y; j++)
                        {
                            d[i, k] += (a[i, j] * c[k, j]);
                        }
                }

                // SONUC MATRİSİNİ EKRANA YAZ
                for (i = 0; i < x; i++)
                    for (j = 0; j < t; j++)
                    {
                        Console.Write("{0,5}", d[i, j]); ;
                        if (j == t - 1) Console.Write("\n");
                    }
            }
            Console.ReadLine();
        }
    }

}