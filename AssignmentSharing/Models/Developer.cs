using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AssignmentSharing.Models
{
    [Index(nameof(Pseudonym), IsUnique = true)]
    public class Developer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudonym { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Issue> Issues { get; set; } = new List<Issue>();

    }
}
