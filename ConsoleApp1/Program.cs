while (true)
{
    Console.Write("Введите Число экспертов: ");
    int experts = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    Console.Write("Введите число целей: ");
    int aims = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    double[,] matrix = new double[experts, aims];
    for (int i = 0; i < experts; i++)
    {
        for (int j = 0; j < aims; j++)
        {
            Console.Write("Введите строку значение " + (i + 1).ToString() + " " + (j + 1).ToString() + ":");
            matrix[i, j] = Convert.ToDouble(Console.ReadLine());
        }
    }
    Console.Clear();

    double[] ratings = new double[experts];
    for (int i = 0; i < experts; i++)
    {
        Console.Write("Введите оценку компетентности эксперта " + (i + 1).ToString() + ": ");
        ratings[i] = Convert.ToDouble(Console.ReadLine());
    }
    Console.Clear();

    double sum = 0;
    for (int i = 0; i < ratings.Length; i++)
    {
        sum = sum + ratings[i];
    }
    double[] zs = new double[experts];
    for (int i = 0; i < experts; i++)
    {
        zs[i] = ratings[i] / sum;
    }
    double[,] weights = new double[2, aims];
    for (int i = 0; i < aims; i++)
    {
        weights[0, i] = 0;
        for (int j = 0; j < experts; j++)
        {
            weights[0, i] = weights[0, i] + matrix[j, i] * zs[j];
        }
        weights[1, i] = i + 1;
    }
    for (int i = 0; i < aims; i++)
    {
        for (int j = 0; j < aims - 1; j++)
        {
            if (weights[0, j] < weights[0, j + 1])
            {
                double t = weights[0, j + 1];
                weights[0, j + 1] = weights[0, j];
                weights[0, j] = t;
                t = weights[1, j + 1];
                weights[1, j + 1] = weights[1, j];
                weights[1, j] = t;
            }
        }
    }
    Console.WriteLine("Лучший вариант: " + weights[1, 0]);
    Console.WriteLine("Завершить работу? +/-");
    string ans = Console.ReadLine();
    if (ans == "+")
    {
        Console.Clear();
    }
    else { break; }
}