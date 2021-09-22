using AutoMapper;
using InstructionNotesApi.Data;
using InstructionNotesApi.Dtos;
using InstructionNotesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructionNotesApi.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class InstructionNotesController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public InstructionNotesController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<NoteReadDto>> GetAllNotes()
        {
            var notes = _repository.GetAllNotes();
            return Ok(_mapper.Map<IEnumerable<NoteReadDto>>(notes));
        }
        // this responds to GET api/notes/{id}
        [HttpGet("{id}", Name = "GetNoteById")]
        public ActionResult<NoteReadDto> GetNoteById(int id)
        {
            var note = _repository.GetNotesById(id);
            if (note == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<NoteReadDto>(note));
            }          
        }

        [HttpPost]
        public ActionResult<NoteReadDto> CreateNote(NoteCreateDto createDto)
        {
            var note = _mapper.Map<InstructionNote>(createDto);
            _repository.CreateNote(note);
            if (_repository.SaveChanges())
            {
                var readDto = _mapper.Map<NoteReadDto>(note);
                return CreatedAtRoute(nameof(GetNoteById), new { Id = readDto.Id }, readDto);
            }
            return BadRequest();
            
        }
        [HttpPut("{id}")]
        public ActionResult<NoteReadDto> PutNote(int id,NotePutDto putDto)
        {
            var noteToUpdate = _repository.GetNotesById(id);
            if (noteToUpdate != null)
            {
               _mapper.Map(putDto, noteToUpdate);
                if (_repository.SaveChanges())
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult PatchNote(int id, JsonPatchDocument<NotePutDto> jsonPatch)
        {
            var originalNote = _repository.GetNotesById(id);
            if (originalNote != null)
            {
                var noteToPatch = _mapper.Map<NotePutDto>(originalNote);
                jsonPatch.ApplyTo(noteToPatch, ModelState);
                if (!TryValidateModel(noteToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                _mapper.Map(noteToPatch, originalNote);
                if (_repository.SaveChanges())
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int id)
        {
            _repository.DeleteNote(id);
            return NoContent();
        }
    }
}
