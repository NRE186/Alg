using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Utils
    {

        //Вычисление minRun
        public int GetMinrun(int n)
        {
            int r = 0;           /* станет 1 если среди сдвинутых битов будет хотя бы 1 ненулевой */
            while (n >= 64)
            {
                r |= n & 1;
                n >>= 1;
            }
            return n + r;
        }
        //Сортировка вставками
        public int[] SortInsertionPart(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = cur;
            }
            return array;
        }
        //Функция слияния двух массивов
        public int[] Merge(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;
            //Копируем в массив c меньшее значение,
            //увеличивая при этом счётчики i, j, k
            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    c[k++] = a[i++];
                }
                else
                {
                    c[k++] = b[j++];
                }
            }
            //Если какой-то массив прошли не до конца,
            //то копируем оставшиеся элементы
            while (i < a.Length)
            {
                c[k++] = a[i++];
            }
            while (j < b.Length)
            {
                c[k++] = b[j++];
            }

            return c;
        }

        public void CreateFile(string text ,int[] array, string time)
        {
            string path = @"Отчёт\";
            string fileName = @"report";
            string file = path + fileName + ".txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(file, true, Encoding.Default))
                {
                    sw.WriteLine(text);
                    for (int i = 0; i < array.Length; i++)
                    {
                        sw.Write(" " + array[i]);
                    }
                    sw.WriteLine();
                    sw.WriteLine("Количество элементов массива - " + array.Length);
                    sw.WriteLine("Время выполнения сортировки - " + time);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LeonardHeap(int[] arr, int len, int index)
        {
            int lar = index;
            int l = 2 * index + 1;
            int r = 2 * index + 2;

            if (l < len && arr[l] > arr[lar])
                lar = l;

            if (r < len && arr[r] > arr[lar])
                lar = r;

            if (lar != index)
            {
                int swap = arr[index];
                arr[index] = arr[lar];
                arr[lar] = swap;

                LeonardHeap(arr, len, lar);

            }

        }
    }
}
