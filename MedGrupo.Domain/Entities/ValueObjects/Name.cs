using MedGrupo.CrossCutting.ValueObjects;

namespace MedGrupo.Domain.Entities.ValueObjects
{
    public class Nome : ValuesObjects
    {
        public Nome() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
