using API_CRUD_Operation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace API_CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDOperationController : ControllerBase
    {
        private readonly MytestdbContext context;

        public CRUDOperationController(MytestdbContext context)
        {
            this.context = context;
        }

        // Return List of Students
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudentData()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }

        // check student through an id
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentByID(int id)
        {
            var studentsdata = await context.Students.FindAsync(id);
            
            if(studentsdata == null)
            {
                return NotFound();
            }

            return studentsdata;
        }

        //Insert Data in Database
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudentData(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        //Update Data in Database
        [HttpPut("{id}")]

        public async Task<ActionResult<Student>> UpdateStudentData(int id , Student std)
        {
           if(id != std.StdId)
            {
                //Generates 404 Bad Request
                return BadRequest();
            }

            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }

        //Delete Record in Database
        [HttpDelete("{id}")]

        public async Task<ActionResult<Student>> DeleteStudentData(int id)
        {
            var find_student = await context.Students.FindAsync(id);

            if(find_student == null)
            {
                return NotFound();
            }

            context.Students.Remove(find_student);
            await context.SaveChangesAsync();
            return Ok();
            
        }
    }
}
