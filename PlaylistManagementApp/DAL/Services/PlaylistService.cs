using PlaylistManagementApp.DAL.Interrfaces;
using PlaylistManagementApp.DAL.Services.Repository;
using PlaylistManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlaylistManagementApp.DAL.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _repository;

        public PlaylistService(IPlaylistRepository repository)
        {
            _repository = repository;
        }

        public Task<Song> AddSongs(Song song)
        {
            return _repository.AddSongs(song);
        }

        public Task<bool> DeleteSongById(long id)
        {
            return _repository.DeleteSongById(id);
        }

        public List<Song> GetPlaylist()
        {
            return _repository.GetPlaylist();
        }

        public Task<Song> GetSongById(long id)
        {
            return _repository.GetSongById(id); ;
        }

        public Task<Song> UpdatePlaylist(Song model)
        {
            return _repository.UpdatePlaylist(model);
        }
    }
}