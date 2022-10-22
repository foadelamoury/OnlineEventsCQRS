using OnlineEvents.Features.PhotoAlbums.Commands;
using OnlineEvents.Features.PhotoAlbums.Queries;
using OnlineEvents.Features.Events.Queries;

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
using OnlineEvents.Features.Images.Commands;

namespace OnlineEvents.Controllers
{
    public class PhotoAlbumController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PhotoAlbumController(IMediator mediator, IWebHostEnvironment hostingEnvironment)
        {
            _mediator = mediator;
            this.hostingEnvironment = hostingEnvironment;


        }
        public async Task<IActionResult> Index(int id)
        {

            return View(await _mediator.Send(new GetEventByIdQuery() { Id = id }));
        }
        public async Task<IActionResult> Details(int id)
        {

            return View(await _mediator.Send(new GetPhotoAlbumByIdQuery() { Id = id }));

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePhotoAlbumCommand command)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Details));
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
            return View(await _mediator.Send(new GetPhotoAlbumByIdQuery() { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdatePhotoAlbumCommand command,CreateImageCommand imageCommand)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    imageCommand.PhotoAlbumId = command.Id;
                    UploadImage(imageCommand);
                    await _mediator.Send(imageCommand);
                    await _mediator.Send(command);
                    return RedirectToAction("Details", "PhotoAlbum", new { id = command.Id });
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
                await _mediator.Send(new DeletePhotoAlbumCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction("Index", "Event", new { area = "" });
        }

        private void UploadImage(CreateImageCommand imageCommand)
        {
            string uniqueFileName = "";
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

                        imageCommand.ImagePath = uniqueFileName;

                    }
                }
            }
        }
    }
}
