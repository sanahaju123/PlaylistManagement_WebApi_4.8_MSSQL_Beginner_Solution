using PlaylistManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlaylistManagementApp.DAL.Services.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly DatabaseContext _dbContext;
        public PlaylistRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Song> AddSongs(Song song)
        {
            try
            {
                var result = _dbContext.Songs.Add(song);
                await _dbContext.SaveChangesAsync();
                return song;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteSongById(long id)
        {
            try
            {
                _dbContext.Songs.Remove(_dbContext.Songs.Single(a => a.SongId == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Song> GetPlaylist()
        {
            try
            {
                var result = _dbContext.Songs.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Song> GetSongById(long id)
        {
            try
            {
                return await _dbContext.Songs.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Song> UpdatePlaylist(Song model)
        {
            var ex = await _dbContext.Songs.FindAsync(model.SongId);
            try
            {
                ex.Artist = model.Artist;
                ex.Title = model.Title;
                ex.Genre = model.Genre;
                ex.Album = model.Album;
                ex.SongId = model.SongId;
                await _dbContext.SaveChangesAsync();
                return ex;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}