using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using githubpublicrepos.Models;
using Microsoft.AspNetCore.Mvc;

namespace githubpublicrepos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoryController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpPost]
        public async Task<ActionResult<List<UserRepositoryDetails>>> GetUserRepositories(GithubUserDetails userDetails)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Github get users public repos using username");

                var responseStream = await client.GetStreamAsync("https://api.github.com/users/" + userDetails.UserName + "/repos");
                
                var repoDetails = await JsonSerializer.DeserializeAsync<List<UserRepositoryDetails>>(responseStream);

                // need to handle the case for any error from github APIs

                return Ok(repoDetails);
            }
            catch (NotSupportedException nse) {
                return BadRequest(nse);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}