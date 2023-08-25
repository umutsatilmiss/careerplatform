using CareerPlatform.Business.Interfaces;
using CareerPlatform.Model.Dtos.Skill;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerPlatform.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SkillController : BaseController
    {
        private readonly ISkillBs _skillBase;
        public SkillController(ISkillBs skillBs)
        {
            _skillBase = skillBs;
        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<SkillGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _skillBase.GetSkillByIdAsync(id, "Users");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<SkillGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            var response = await _skillBase.GetSkillAsync("Users");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<SkillGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByDescription")]
        public async Task<IActionResult> GetByDescription([FromQuery] string description)
        {
            var response = await _skillBase.GetSkillByDescriptionAsync(description, "Users");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<SkillGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByLevelName")]
        public async Task<IActionResult> GetByLevelName([FromQuery] string level)
        {
            var response = await _skillBase.GetSkillByLevelNameAsync(level, "Users");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<SkillGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var response = await _skillBase.GetSkillByNameAsync(name, "Users");
            return SendResponse(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Skill>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewCategory([FromBody] SkillPostDto dto)
        {
            var response = await _skillBase.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetById), new { id = response.Data.SkillId }, response.Data);
            }
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateSkill([FromBody] SkillPutDto dto)
        {
            var response = await _skillBase.UpdateAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill([FromRoute] int id)
        {
            var response = await _skillBase.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
