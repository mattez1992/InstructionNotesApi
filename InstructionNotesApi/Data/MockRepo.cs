using InstructionNotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructionNotesApi.Data
{
    public class MockRepo : IRepository
    {
        public void CreateNote(InstructionNote note)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote()
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InstructionNote> GetAllNotes()
        {
            List<InstructionNote> instructionNotes = new()
            {
                new InstructionNote { Id = 1, Description = "How to cook pasta", Execution = "Boil water and put pasta in", Tools = "Kettle and pasta" },
                new InstructionNote { Id = 2, Description = "How to wash your hair", Execution = "Use shampo on hair and wash in shower", Tools = "Shampoo and Shower" },
                new InstructionNote { Id = 3, Description = "How to make lemonade", Execution = "Use lemonade mix and water", Tools = "Lemonade mix and water" },
                new InstructionNote { Id = 4, Description = "How to make coffe", Execution = "Boil water and put coffe in", Tools = "Kettle and coffe" }
            };
            return instructionNotes;
        }

        public InstructionNote GetNotesById(int id)
        {
            return new InstructionNote { Id = 1, Description = "How to cook pasta", Execution = "Boil water", Tools = "Kettle and pasta" };
        }

        public void PutNote(InstructionNote note)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
