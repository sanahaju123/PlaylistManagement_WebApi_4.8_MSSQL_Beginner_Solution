using PlaylistManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistManagementApp.DAL.Interrfaces
{
    public interface IPlaylistService
    {
        List<Song> GetPlaylist();
        Task<Song> AddSongs(Song song);
        Task<Song> GetSongById(long id);
        Task<bool> DeleteSongById(long id);
        Task<Song> UpdatePlaylist(Song model);
    }
}
