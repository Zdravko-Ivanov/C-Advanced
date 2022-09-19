using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Renovators
{
    public class Catalog
    {
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get; set; }
        public List<Renovator> Renovators { get; set; }

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.Renovators = new List<Renovator>();
        }

        public string AddRenovator(Renovator renovator)
        {

            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's inforarmation.";
            }
            if (this.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                this.Count++;
                this.Renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }

        }
        public bool RemoveRenovator(string name)
        {
            int isthereany = this.Renovators.RemoveAll(x => x.Name == name);
            if (isthereany != 0)
            {
                this.Count -= isthereany;
                return true;
            }
            else return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int temp = this.Renovators.RemoveAll(x => x.Type == type);
            this.Count -= temp;
            return temp;
        }
        public Renovator HireRenovator(string name)
        {
            foreach (var renovator in Renovators)
            {
                if (renovator.Name == name)
                {
                    renovator.Hired = true;
                    return renovator;
                }
            }
            return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            return this.Renovators.Where(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            return $"Renovators available for Project {this.Project}:" + Environment.NewLine +
            $"{string.Join(Environment.NewLine, this.Renovators.Where(x => x.Hired == false))}";
        }

    }
}
