using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Service.DTOs.Note;
using ApsisYönetim.Web.AdminConfig;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Controllers
{
    
    public class NoteController : Controller
    {
        private readonly INoteService _noteService = null;
        private readonly IMapper _mapper = null;
        private readonly IAdminEmail _adminEmail = null;

        public NoteController(IAdminEmail adminEmail,INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
            _adminEmail = adminEmail;
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        public async Task<IActionResult> ShowMessagesHaveAdmin()
        {
            string email = _adminEmail.Email;
            var result = await _noteService.GetAllAsync(x => x.Receiver == email);
            List<Note> notes = result.Data;
            List<ShowNotesDto> notesDto = _mapper.Map<List<ShowNotesDto>>(notes); 


            return View(notesDto);
        }

        [Authorize(Roles = nameof(Roles.User))]
        public IActionResult AddNoteToAdmin()
        {
            return View();
        }

        [Authorize(Roles = nameof(Roles.User))]
        [HttpPost]
        public async Task<IActionResult> AddNoteToAdmin(AddNoteDto noteDto)
        {

            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();

                return View(noteDto);

            }
            Note note = _mapper.Map<Note>(noteDto);

            string userEmail = HttpContext.Session.GetString("email");
            note.Sender = userEmail;
            note.Receiver = _adminEmail.Email;


            var result = await _noteService.AddAsync(note);

            if (result.Success)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("AddNoteToAdmin");
        }
    }
}
