namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    class Developer : Employee, IDeveloper
    {
        private IList<Project> projects;
        
        public Developer(string firstName, string lastName, int id, decimal salary, Department department)
            : base(firstName, lastName, id, salary, department)
        {
            this.projects = new List<Project>();
        }

        public Developer(string firstName, string lastName, int id, decimal salary, Department department, IList<Project> projects)
            : this(firstName, lastName, id, salary, department)
        {
            this.projects = projects;
        }
        
        public void AddProject(Project project)
        {
            this.projects.Add(project);
        }
        
        public override string ToString()
        {
            return base.ToString() + "\n" +
            string.Format("Projects:\n{0}", string.Join("\n", this.projects));
        }
      
    }
}
