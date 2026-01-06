using MediCare.Domain.HR.Models.Commands;
using MediCare.Domain.HR.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.HR.Controllers;

/// <summary>
///  AppointmentController class that is responsible for handling the appoinments requests.
/// </summary>
[Route("api/v1/appointments")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppoinmentCommandService _appoinmentCommandService;
    /// <summary>
    /// Initializes a new instance of the <see cref="AppointmentController"/> class.
    /// </summary>
    /// <param name="appoinmentCommandService">The service handling appoinments commands.</param>
    public AppointmentController(IAppoinmentCommandService appoinmentCommandService)
    {
        _appoinmentCommandService = appoinmentCommandService;
    }
    // POST api/v1/appointments
    /// <summary>
    /// Creates a new appointments based on the provided appointment command.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/v1/appointments
    ///     {
    ///        "patientName": "Your Name",
    ///        "doctorName": "Doctor Name",
    ///        "email": "Your Email",
    ///        "speciality": "speciality",
    ///         "appoinmentDate": "2024-06-14",
    ///         "appoinmentTime": "10:30:00"
    ///     }
    ///
    /// </remarks>
    /// <param name="command">The command object containing all necessary data to create an appoitment.</param>
    /// <response code="201">Returns the newly created appointment.</response>
    /// <response code="400">If the appointment has invalid property</response>
    /// <response code="409">Error validating data</response>
    /// <response code="500">Unexpected error</response>
    [HttpPost]
    public async Task<IActionResult> CreatePlan([FromBody] CreateAppointmentCommand command)
    {
        if (!ModelState.IsValid) return BadRequest();
        try
        {
            var result = await _appoinmentCommandService.Handle(command);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}