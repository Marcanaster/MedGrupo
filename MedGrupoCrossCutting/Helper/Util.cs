using System;

namespace MedGrupo.CrossCutting.Helper
{
    public static class Util
    {
        public static int CalculaIdade(DateTime? birthdate)
        {
            var age = 0;

            if (birthdate == null) throw new ArgumentNullException();

            var today = new DateTime(2023, 1, 24);
            age = today.Year - birthdate.Value.Year;
            if (birthdate > today.AddYears(-age)) age--;

            return age;
        }
    }
}
