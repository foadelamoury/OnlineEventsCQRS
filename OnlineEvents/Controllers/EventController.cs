using OnlineEvents.Features.Events.Commands;
using OnlineEvents.Features.Events.Queries;

using OnlineEvents.Features.Sources.Queries;
using OnlineEvents.Features.Sources.Commands;

using OnlineEvents.Features.PhotoAlbums.Commands;
using OnlineEvents.Features.PhotoAlbums.Queries;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineEvents.Models;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineEvents.Controllers
{
    public class EventController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment hostingEnvironment;



        public EventController(IMediator mediator, IWebHostEnvironment hostingEnvironment)
        {
            _mediator = mediator;
            this.hostingEnvironment = hostingEnvironment;


        }
     
        public async Task<IActionResult> Index()
        {

            return View(await _mediator.Send(new GetAllEventsQuery())) ;
        }
        public async Task<IActionResult> Details(int id)
        {
           
            return View(await _mediator.Send(new GetEventByIdQuery() { Id = id }));
          
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventCommand command, CreateSourceCommand sourceCommand,string sourceName,string SourceDescription)
        {

            try
            { 
                if (ModelState.IsValid)
                {
                    UploadCoverPhoto(command);
                    sourceCommand.Id = command.CategoryId+20;
                    sourceCommand.Name = sourceName;
                    sourceCommand.Description = SourceDescription;
                    command.SourceId = sourceCommand.Id;
                    await _mediator.Send(command);
                    await _mediator.Send(sourceCommand);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _mediator.Send(new GetEventByIdQuery() { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateEventCommand command,CreatePhotoAlbumCommand photoAlbumCommand)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    photoAlbumCommand.Id = command.Id;
                    
                    await _mediator.Send(photoAlbumCommand);
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteEventCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }

      


        


        private void UploadCoverPhoto(CreateEventCommand command)
        {
            string uniqueFileName = null;
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                     string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    var file = Image;

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse
                            (file.ContentDisposition).FileName.Trim('"');

                        System.Console.WriteLine(fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        //await file.CopyToAsync(fileStream);
                        command.CoverPhotoPath = uniqueFileName;


                    }
                }
            }
        }
    }
}
