using System.Collections;

namespace List;



class Program
{


    static void Main()
    {
        //List<int> norm_list = new List<int> { 1, 2, 2, 4, 5 };
        List list = new(1,2,3,4,5);


        int sum = list.Add();

        Console.WriteLine(sum);

    }
}




class List (params int[] array) : IEnumerable
{
    private int[] list = array;

    public int this[int index]
    {
        get { return list[index]; }
        set { list[index] = value; }
    }

    #region Properties

    private bool IsEmpty { get => (list != null); }

    public int Lenght { get => list.Length; }

    //public int Capacity { get; set; }
    #endregion

    public void Append(params int[] values)
    {
        int[] array = new int[Lenght + values.Length];

        for (int i = 0; i < (Lenght + values.Length); i++)
        {
            if (!IsEmpty)
                array[i] = list[i];

            if (i < values.Length && !IsEmpty)
                array[Lenght + i] = values[i];
        }
        list = array;
    }

    public float Average()
    {
        float sum = 0;

        for (int i = 0; i < Lenght; i++)
            sum += list[i];

        return sum / Lenght;
    }

    public void Clear() => list = null;

    public bool Contains(int value)
    {
        foreach (int i in list)
            if (i == value) 
                return true;
        return false;
    }

    #region Sort
    public void Sort()
    {
        if (IsEmpty)
            return;

        int[] soted_list = new int[Lenght];
        int len = Lenght;
        int index;

        for (uint i = 0; i < len; i++)
        {
            (soted_list[i], index) = _Min();
            Delete(index);
        }

        list = soted_list;

    }

    private (int min_value, int index) _Min()
    {
        int min = list[0];
        int min_index = 0;

        for (int i = 0; i < Lenght; i++)
            if (list[i] < min)
            {
                min = list[i];
                min_index = i;
            }
        return (min, min_index);
    }
    #endregion

    public int Add(int index = 0, int sum = 0)
    {
        if (++index >= Lenght)
            return 0;

        sum = Add(index, sum);

        return sum += list[index];
    }

    public int Max()
    {
        int max = list[0];

        foreach(int i in list) 
            if (i > max)
                max = i;

        return max;
    }

    public int Min()
    {
        int min = list[0];

        foreach (int value in list)
            if (value < min)
                min = value;

        return min;
    }

    public void Display()
    {
        foreach (int i in list)
            Console.Write(i + " ");

        Console.WriteLine();
    }

    public void Delete(int index)
    {
        int[] array = new int[Lenght - 1];

        for (int i = 0; i < index; i++)
            array[i] = list[i];

        for (int i = index + 1; i < Lenght; i++)
            array[i - 1] = list[i];

        list = array;
    }

    public void Pop(int value)
    {
        for (int i = 0; i < Lenght; i++)
            if (list[i] == value)
            {
                Delete(i);
                return;
            }
    }

    public void Set_by_Random(uint count, int min_value, int max_value, uint start_index = 0)
    {
        Random random = new();

        int[] array = new int[count];

        for (; start_index < array.Length; start_index++)
            array[start_index] = random.Next(min_value, max_value + 1);

        list = array;
    }

    public IEnumerator GetEnumerator()
    {
        foreach (int i in list) 
            yield return i;
    }
}

