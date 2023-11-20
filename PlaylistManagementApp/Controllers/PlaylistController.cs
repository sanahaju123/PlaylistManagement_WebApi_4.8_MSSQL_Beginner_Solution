using PlaylistManagementApp.DAL.Interrfaces;
using PlaylistManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PlaylistManagementApp.Controllers
{
    public class PlaylistController : ApiController
    {
        private readonly IPlaylistService _service;
        public PlaylistController(IPlaylistService service)
        {
            _service = service;
        }
        public PlaylistController()
        {
            // Constructor logic, if needed
        }

        [HttpPost]
        [Route("api/Playlist/CreatePlaylist")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreatePlaylist([FromBody] Song model)
        {
            var leaveExists = await _service.GetSongById(model.SongId);
            var result = await _service.AddSongs(model);
            return Ok(new Response { Status = "Success", Message = "Song created successfully!" });
        }


        [HttpPut]
        [Route("api/Playlist/UpdatePlaylist")]
        public async Task<IHttpActionResult> UpdatePlaylist([FromBody] Song model)
        {
            var result = await _service.UpdatePlaylist(model);
            return Ok(new Response { Status = "Success", Message = "Song updated successfully!" });
        }


        [HttpDelete]
        [Route("api/Playlist/DeletePlaylist")]
        public async Task<IHttpActionResult> DeletePlaylist(long id)
        {
            var result = await _service.DeleteSongById(id);
            return Ok(new Response { Status = "Success", Message = "Song deleted successfully!" });
        }


        [HttpGet]
        [Route("api/Playlist/GetSongById")]
        public async Task<IHttpActionResult> GetSongById(long id)
        {
            var expense = await _service.GetSongById(id);
            return Ok(expense);
        }


        [HttpGet]
        [Route("api/Playlist/GetAllSongs")]
        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            return _service.GetPlaylist();
        }
    }
}
