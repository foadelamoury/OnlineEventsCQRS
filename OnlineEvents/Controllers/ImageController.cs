using OnlineEvents.Features.PhotoAlbums.Commands;
using OnlineEvents.Features.PhotoAlbums.Queries;
using OnlineEvents.Features.Events.Queries;
using OnlineEvents.Features.Images.Commands;
using OnlineEvents.Features.Images.Queries;
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
    public class ImageController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ImageController(IMediator mediator, IWebHostEnvironment hostingEnvironment)
        {
            _mediator = mediator;
            this.hostingEnvironment = hostingEnvironment;


        }
        public async Task<IActionResult> Index(int id)
        {

            return View(await _mediator.Send(new GetSourceByIdQuery() { Id = id }));
        }
        public async Task<IActionResult> Details(int id)
        {

            return View(await _mediator.Send(new GetSourceByIdQuery() { Id = id }));

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateImageCommand command)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    await _mediator.Send(command);
                    return RedirectToAction("Index", "Event", new { area = "" });
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
                await _mediator.Send(new DeleteImageCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction("Index", "Event", new { area = "" });
        }
        

    }
}
