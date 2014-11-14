using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StudentClass
{
    public delegate void ChangedPropartyEventHahdler( object sender, PropertyChangedEventArgs e);
    public class PropertyChangedEventArgs : EventArgs
    {
        public string propertyName { get; set; }
        public string oldValue { get; set; }
        public string newValue { get; set; }
    }

    public class Student 
    {
        private string name;
        private uint age;
        public event ChangedPropartyEventHahdler PropertyChanged;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name must not to be null or empty string.");
                }
                SetPropertyField("Name", ref this.name, value);
            }

        }

        public uint Age
        {
            get { return this.age; }
            set
            {
                if (age < 0)
                {
                    throw new ArgumentException("The age must not to be negative.");
                }
                SetPropertyField("Age", ref this.age, value);
            }

        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            ChangedPropartyEventHahdler handler = PropertyChanged;
            Console.WriteLine("Property changed: {0} (from {1} to {2}).", e.propertyName, e.oldValue, e.newValue);
            if (handler != null)
                handler(this, e);
        }

        protected void SetPropertyField<T>(string prName, ref T field, T newV)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newV))
            {
                if (field != null )
                {
                    if(field.ToString() != "0")
                    {
                        PropertyChangedEventArgs ev = new PropertyChangedEventArgs { propertyName = prName, oldValue = field.ToString(), newValue = newV.ToString() };
                        OnPropertyChanged(ev);
                    }
                    
                }

                field = newV;
            }
        }


        public Student(string name, uint age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}

