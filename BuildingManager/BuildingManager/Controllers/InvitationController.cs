﻿using Microsoft.AspNetCore.Mvc;
using APIModels.InputModels;
using ILogic;
using Logic;
using Microsoft.Identity.Client;

namespace BuildingManager.Controllers
{
    [Route("api/invitations")]
    public class InvitationController : Controller
    {

        private readonly IInvitationLogic _invitationLogic;
        public InvitationController(IInvitationLogic logic)
        {
            _invitationLogic = logic;

        }

        [HttpPost]
        public IActionResult CreateInvitation([FromBody] InvitationRequest received)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newInvitation = _invitationLogic.CreateInvitation(received.ToInvitationRequest());
            return CreatedAtAction(nameof(CreateInvitation), new { id = newInvitation.Id }, newInvitation);
        }

        [HttpPost("accept")]
        public IActionResult AcceptInvitation([FromBody] AcceptInvitationRequest received) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try
            {
                var newUser = _invitationLogic.AcceptInvitation(received);
                return CreatedAtAction(nameof(AcceptInvitation), new { id = newUser.Id }, newUser);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetInvitation([FromRoute] int id)
        {

            try
            {
                var result = _invitationLogic.GetInvitationById(id);
                return Ok(result);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvitation([FromRoute]int id) {

            _invitationLogic.DeleteInvitation(id);
            return Ok();

        }

    }
}


