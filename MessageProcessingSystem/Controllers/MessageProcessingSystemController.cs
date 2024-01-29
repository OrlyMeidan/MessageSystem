using Microsoft.AspNetCore.Mvc;
using Service;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MessageProcessingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageProcessingSystemController : ControllerBase
    {

        private readonly ILogger<MessageProcessingSystemController> _logger;
        private readonly IServiceA _serviceA;
        private readonly IServiceB _serviceB;
        private readonly IServiceC _serviceC;

        public MessageProcessingSystemController(ILogger<MessageProcessingSystemController> logger, IServiceA serviceA, IServiceB serviceB, IServiceC serviceC)
        {
            _logger = logger;
            _serviceA = serviceA;
            _serviceB = serviceB;
            _serviceC = serviceC;
        }

        /// <summary>
        /// Returns SaveMessage
        /// </summary>
        /// <param name="accountHolderId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ServiceA")]
        [SwaggerResponse(StatusCodes.Status200OK, "Message saved")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Message does not saved")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error")]
        public async Task<IActionResult> AddMessageAsync(string message)
        {
            _logger.LogInformation($"AddMessage  : {message}");
            try
            {
                var result = await _serviceA.AddMessage(message).ConfigureAwait(false);

                if (result == null)
                {
                    return BadRequest($"Message Not saved.");

                }

                _logger.LogInformation($"finish Addind Message  : {message}");


                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when try to Add message : {message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        /// <summary>
        /// Returns SaveMessage
        /// </summary>
        /// <param name="accountHolderId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ServiceB")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Message")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Message does not exist")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error")]
        public async Task<IActionResult> GetMessageAndSaveInRedisAsync(string message)
        {
            _logger.LogInformation($"AddMessage  : {message}");
            try
            {
                var result = await _serviceB.GetMessageAndSaveInRedis(message).ConfigureAwait(false);

                if (result == null)
                {
                    return BadRequest($"Message Not saved.");

                }

                _logger.LogInformation($"finish Addind Message  : {message}");


                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when try to Add message : {message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        /// <summary>
        /// Returns SaveMessage
        /// </summary>
        /// <param name="accountHolderId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ServiceC")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Message")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Message does not exist")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error")]
        public async Task<IActionResult> GetRandomFromRedisAsync(string message)
        {
            _logger.LogInformation($"Get Numbrt from Redid   : {message}");
            try
            {
                var result = await _serviceC.GetRandomFromRedis(message).ConfigureAwait(false);

                if (result == null)
                {
                    return BadRequest($"Message Not found in redis.");

                }

                _logger.LogInformation($"finish Get Numbrt from Redid  : {message}");


                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when try to Add message : {message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        
    }
}
