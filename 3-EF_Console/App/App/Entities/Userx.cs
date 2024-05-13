using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities;

public class Userx
{
    public int Id { get; set; }
    public required string Name { get; set; }   
    public int Age { get; set; }
    public required string City { get; set; }

    public ICollection<Orderx> Orders { get; set; } = new List<Orderx>();

    public override string ToString()
    {
        return $"{Id} - {Name} - {Age} - {City}";
    }
}
