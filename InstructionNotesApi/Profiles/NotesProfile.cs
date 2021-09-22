using AutoMapper;
using InstructionNotesApi.Dtos;
using InstructionNotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructionNotesApi.Profiles
{
    public class NotesProfile : Profile
    {
        public NotesProfile()
        {
            CreateMap<InstructionNote, NoteReadDto>();
            CreateMap<NoteCreateDto, InstructionNote>();
            CreateMap<NotePutDto, InstructionNote>();
            CreateMap<InstructionNote, NotePutDto>();
        }
    }
}
