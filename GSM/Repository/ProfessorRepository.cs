using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSM.ADO.NETModels;

namespace GSM.Repository
{
    internal class ProfessorRepository
    {
        private ezeEntities1 context;
        private static ProfessorRepository instance = null;

        private ProfessorRepository()
        {
            context = new ezeEntities1();
        }

        public static ProfessorRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ProfessorRepository();
            }
            return instance;
        }

        public List<Professor> getProfessors()
        {
            List<Professor> professors = context.Professors.ToList();
            return professors; 
        }

        public Professor findProfessor(String name)
        {
            List<Professor> professors = context.Professors.Where(p => p.Name == name).ToList();
            if(professors.Count > 0)
            {
                return professors[0];
            } else
            {
                return null;
            }
        }
    }
}
