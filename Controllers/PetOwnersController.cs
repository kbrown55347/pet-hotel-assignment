using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetOwnersController : ControllerBase
  {
    private readonly ApplicationContext _context;
    public PetOwnersController(ApplicationContext context)
    {
      _context = context;
    }

    // This is just a stub for GET / to prevent any weird frontend errors that 
    // occur when the route is missing in this controller
    // [HttpGet]
    // public IEnumerable<PetOwner> GetPets()
    // {
    //   return new List<PetOwner>();
    // }

    [HttpGet]
    public IEnumerable<PetOwner> GetAll()
    {
      return _context.PetOwners;
    }

    // GET /api/petowners/:id
    [HttpGet("{id}")]
    public ActionResult<PetOwner> GetById(int id)
    {
      PetOwner petOwner = _context.PetOwners
          .SingleOrDefault(petOwner => petOwner.id == id);

      // Return a `404 Not Found` if the baker doesn't exist
      if (petOwner is null)
      {
        return NotFound();
      }

      return petOwner;
    }

    // POST /api/petowners
    // Note that .NET parses our JSON request body for us
    // and converts it to a `Pet Owner` model object.
    [HttpPost]
    public PetOwner Post(PetOwner petOwner)
    {
      _context.Add(petOwner);
      _context.SaveChanges();

      return petOwner;
    }

  }
}
