using InstructionNotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructionNotesApi.Data
{
    public interface IRepository
    {
        IEnumerable<InstructionNote> GetAllNotes();
        InstructionNote GetNotesById(int id);
        void CreateNote(InstructionNote note);
        void PutNote(InstructionNote note);
        void DeleteNote(int id);
        bool SaveChanges();
    }
}
