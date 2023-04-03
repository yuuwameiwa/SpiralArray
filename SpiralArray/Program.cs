using SpiralArray;
using System.Buffers;

namespace SpiralArray
{
    internal class Program
    {
        static void Main()
        {

            bool restart = false;
            int arraySize = 0;

            do
            {
                try
                {
                    restart = false;

                    Console.Write("Введите размер массива числом:");

                    arraySize = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Пожалуйста-пожалуйста, введите число!");
                    restart = true;
                }
            }
            while (restart);

            if (arraySize != 0)
            {
                // Создание массива
                int[,] spiralArray = new int[arraySize, arraySize];

                // Уровень устанавливает лимит для позиций
                int level = 0;

                // Значение числа
                int value = 0;
                int firstPositionValue = -1;
                int secondPositionValue = -1;

                int order = 0;

                for (int i = 0; i < arraySize * 2 - 1; i++)
                {
                    order++;
                    if (order > 4)
                    {
                        order = 1;
                    }

                    if (i != 0)
                    {
                        if (order == 2 || order == 4)
                            level++;
                    }

                    for (int j = 1; j <= arraySize - level; j++)
                    {
                        SpiralInteger spiralInteger = new SpiralInteger();

                        value++;
                        spiralInteger.Value = value;

                        switch (order)
                        {
                            case 1:
                                secondPositionValue++;

                                if (firstPositionValue == -1)
                                    firstPositionValue++;

                                spiralInteger.FirstPosition = firstPositionValue;
                                spiralInteger.SecondPosition = secondPositionValue;
                                break;
                            case 2:
                                firstPositionValue++;
                                spiralInteger.FirstPosition = firstPositionValue;
                                spiralInteger.SecondPosition = secondPositionValue;
                                break;
                            case 3:
                                secondPositionValue--;
                                spiralInteger.FirstPosition = firstPositionValue;
                                spiralInteger.SecondPosition = secondPositionValue;
                                break;
                            case 4:
                                firstPositionValue--;
                                spiralInteger.FirstPosition = firstPositionValue;
                                spiralInteger.SecondPosition = secondPositionValue;
                                break;
                        }

                        spiralArray[spiralInteger.FirstPosition, spiralInteger.SecondPosition] = spiralInteger.Value;
                    }
                }

                int newLine = 0;
                foreach (int spiralInt in spiralArray)
                {
                    if (newLine % arraySize == 0)
                    {
                        Console.WriteLine("\r\n");
                    }

                    newLine++;

                    Console.Write(spiralInt + " ");
                }
            }
        }
    }
}