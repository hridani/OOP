namespace School
{
    using System;
    using System.Collections.Generic;

    public class Teacher:People
    {
        private IList<Discipline> disciplines;

        public Teacher(string name)
            :base(name)
        {
            this.disciplines = new List<Discipline>();
        }

        public Teacher(string name, List<Discipline> disciplines)
            :this(name)
        {
            this.disciplines=disciplines;
        }

        public Teacher(string name, List<Discipline> disciplines, string detail)
            :this(name, disciplines)
        {
            this.Detail = detail;
        }

         
        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }
    
    }
}
