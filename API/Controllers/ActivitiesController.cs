using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {   // inject DataContext here
        private readonly DataContext _context; // initialize from parameter DataContext context
        // instead of calling this initialized context, use (_context)
        public ActivitiesController(DataContext context) // specific DataContext here by calling it context
        {
            // inject DataContext in this particular class
            _context = context; // this is the initialized _context = specified DataContext parameter
            
        }
        [HttpGet] // go to => api/activities 
        public async Task<ActionResult<List<Activity>>> GetActivities(){
            // return list of activities
            return await _context.Activities.ToListAsync();
        }
        [HttpGet("{id}")] // api/activities/{id} => {id}= sdfsfkjqekhwqekwfkjw
        public async Task<ActionResult<Activity>> GetActivity(Guid id){
            // find via id and return the specific Activity 
            return await _context.Activities.FindAsync(id);
        }
    }
}