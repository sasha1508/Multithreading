﻿
int x = 0;
object locker = new();  // объект-заглушка

// запускаем пять потоков:
for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";
    myThread.Start();
}

void End(string stroka)
{
    Console.WriteLine(stroka);
}

void Print()
{
    lock (locker)
    {
        //x = 1;
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
        }
        End("Выполнено");
    }
}