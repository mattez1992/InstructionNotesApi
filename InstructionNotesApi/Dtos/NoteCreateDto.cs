using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstructionNotesApi.Dtos
{
    public class NoteCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(250)]
        public string Execution { get; set; }
        [Required]
        public string Tools { get; set; }
    }
}
