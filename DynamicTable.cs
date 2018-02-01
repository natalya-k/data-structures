namespace DataStructures
{
    class DynamicTable
    {
        private int[] array;
        int top;

        public DynamicTable(int length = 1)
        {
            array = new int[length];
            top = 0;
        }

        public void Add(int item)
        {
            if (top == array.Length)
            {
                int[] copy = new int[array.Length * 2];

                for (int i = 0; i < array.Length; i++)
                {
                    copy[i] = array[i];
                }

                array = copy;
            }

            array[top] = item;
            top++;
        }
    }
}
