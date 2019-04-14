using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sort
{
    class SortMethods : Randomizer
    {
        Stopwatch myStopwatch = new Stopwatch();
        Utils utils = new Utils();

        public int N { get; set; }

        public void TimSort()
        {
            //Запуск таймера
            myStopwatch.Start();
            //Инициализация переменных
            int[] sort = RandomArray(N);
            int minRun = utils.GetMinrun(N);
            int currentIndex = 0;
            List<int> run = new List<int>();
            int[] res = new int[N];
            int test = 0;
            while (currentIndex != sort.Length)
            {
                run.Add(sort[currentIndex]);
                currentIndex++;
                run.Add(sort[currentIndex]);
                currentIndex++;
                //Проверка следующего элемента за первыми двумя в run'е
                while (run.Last() < sort[currentIndex + 1] && currentIndex != sort.Length)
                {
                    run.Add(sort[currentIndex + 1]);
                    currentIndex++;
                }
                //Если количество элементов run'а меньше вычисленного minrun, то добавляем (minRun - run.Count) элементов в массив
                if (run.Count < minRun)
                {
                    int dif = minRun - run.Count;
                    int tmp = 0;
                    while (tmp != dif && currentIndex != sort.Length)
                    {
                        run.Add(sort[currentIndex]);
                        currentIndex++;
                        tmp++;
                    }
                }
                //Сортировка вставками получившегося run'а
                int[] r = utils.SortInsertionPart(run.ToArray());
                //Слияние массивов в результирующий массив res
                if (test == 0)
                {
                    res = r;
                    test++;
                }
                else
                {
                    res = utils.Merge(res, r);
                }
                //Удаление значений предыдущих run'ов из памяти
                int t = 0;
                List<int> temp = new List<int>();
                temp = r.ToList();
                while (run.Count != 0)
                {
                    run.Remove(run.ElementAt(t));
                    temp.Remove(temp.ElementAt(t));
                }
                r = temp.ToArray();
            }
            myStopwatch.Stop();
            Console.WriteLine("Сортировка прошла успешно");
            //Время выполнения
            TimeSpan time = myStopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                time.Hours, time.Minutes, time.Seconds,
                time.Milliseconds / 10);
            //Вспомогательная функция для записи результатов сортировки в файл
            string ts = "TimSort ";
            ts += DateTime.Now.ToLocalTime();
            string str = new String('-', N - ts.Length);
            str += ts;
            str += new String('-', N - ts.Length);
            utils.CreateFile(str, res, time.ToString());
        }
    }
}
