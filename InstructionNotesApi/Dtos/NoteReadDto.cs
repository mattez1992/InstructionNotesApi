using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructionNotesApi.Dtos
{
    public class NoteReadDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Execution { get; set; }
        //public string Tools { get; set; }
    }
}
