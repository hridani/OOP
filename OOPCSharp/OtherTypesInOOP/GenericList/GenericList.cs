using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    [Version(1, 1)]
    public class GenericList<T> where T : IComparable<T>
    {
        const int DefaultCapacity = 16;
        private T[] elements;
        private int count = 0;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements= new T[capacity];
        }

        public int Count 
        {
            get { return this.count; }
            set { this.count = value; }
        }
        
        public void Add(T element)
        {
            if(this.count >= elements.Length)
            {
                throw new IndexOutOfRangeException(string.Format(
                    "The list capacity of {0} was exceeded.",elements.Length));
            }
            this.elements[count]=element;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if(index<0 || index>=this.Count)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}\n",index));
                }
                T result=this.elements[index];
                return result;
            }
            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("The required index is invalid!");
                }
                this.elements[index] = value;
            }
        }
        
        public void Insert(int index, T element)
        {
            if (index > this.Count || index < 0)
            {
                throw new IndexOutOfRangeException(
                  "Invalid index:" + index);
            }
            T[] extendedT = elements;
            if(this.Count+1 == elements.Length)
            {
                extendedT = new T[elements.Length * 2];
            }
            Array.Copy(this.elements, extendedT, index);
            this.Count++;
            Array.Copy(this.elements,index, extendedT, index + 1, this.Count - index - 1);
            extendedT[index] = element;
            elements = extendedT;


        }
       
        
        public int IndexOf(T element)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (this.elements[i].Equals(element))
                    return i;
            }
            return -1;
        }
       
        public void Clear()
        {
            elements = new T[DefaultCapacity];
            this.Count=0;
        }
        
        public bool Contains(T element)
        {
            int index = IndexOf(element);
            bool found = (index != -1);
            return found;
        }
        
        public void Remove(int index)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException(
                  "Invalid index:" + index);
            }
            T element = this.elements[index];
            Array.Copy(this.elements, index + 1, this.elements, index, count - index + 1);
            
            this.Count--;

        }

        public T Max()
        {
            var max = this.elements[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (max.CompareTo(this.elements[i]) < 0)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }
        public T Min()
        {
            var min = this.elements[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (min.CompareTo(this.elements[i]) > 0)
                {
                    min = this.elements[i];
                }
            }
            return min;
        }

        public override string ToString()
        {
          
            return String.Join(", ", this.elements.Where(elem=> elem!=null));
        }

       
    }


  
    class GenericListTest
    {
        static void Main(string[] args)
        {

            GenericList<string> list = new GenericList<string>();
            list.Add("Pesho");
            list.Add("Dani");
            list.Add("");
            list.Add("Christo");
            list.Add("K.G");
            list.Add("dani");
            
            Console.WriteLine(list);
            list[4] = "haha";
            Console.WriteLine(list);
            list.Add("17");
            Console.WriteLine(list);
            Console.WriteLine("list[2] = " + list[2]);
            Console.WriteLine();
            list.Remove(list.Count - 1);
            Console.WriteLine(list);
            Console.WriteLine();
            list.Insert(list.IndexOf(list[2]), "Ivanka");
            Console.WriteLine(list);
            Console.WriteLine();
            Console.WriteLine(list[3]);
            
            Console.WriteLine("Max = "+ list.Max());
           Console.WriteLine("Min = " + list.Min());
            Console.WriteLine();
            list.Clear();
            Console.WriteLine("Empty list" + list);
            Type type = typeof(GenericList<>);
            object[]  allAttributes = type.GetCustomAttributes(typeof(VersionAttribute), false);
            Console.WriteLine("GenericsList's version is {0}", ((VersionAttribute)allAttributes[0]));

        }
   
}
