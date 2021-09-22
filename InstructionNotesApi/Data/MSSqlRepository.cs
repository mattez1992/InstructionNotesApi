using InstructionNotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructionNotesApi.Data
{
    // Repo For Microsoft sql server
    public class MSSqlRepository : IRepository
    {
        private readonly NotesContext _notesContext;

        public MSSqlRepository(NotesContext notesContext)
        {
            _notesContext = notesContext;
        }

        public void CreateNote(InstructionNote note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            _notesContext.Notes.Add(note);

        }

        public void DeleteNote(int id)
        {
            var noteToDelete = _notesContext.Notes.FirstOrDefault(note => note.Id == id);
            if (noteToDelete != null)
            {
                _notesContext.Notes.Remove(noteToDelete);
            }
        }

        public IEnumerable<InstructionNote> GetAllNotes()
        {
            return _notesContext.Notes.ToList();
        }

        public InstructionNote GetNotesById(int id)
        {
            return _notesContext.Notes.FirstOrDefault(note => note.Id == id);
        }

        public void PutNote(InstructionNote note)
        {
            
        }

        public bool SaveChanges()
        {

            return _notesContext.SaveChanges() > 0;
            
        }
    }
}
