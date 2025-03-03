using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;


namespace API.Controllers;


public class ActivitiesController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(String id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null) return NotFound();

        return activity;
    }

}