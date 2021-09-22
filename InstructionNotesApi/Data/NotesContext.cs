using InstructionNotesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructionNotesApi.Data
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<InstructionNote> Notes { get; set; }
    }
}
