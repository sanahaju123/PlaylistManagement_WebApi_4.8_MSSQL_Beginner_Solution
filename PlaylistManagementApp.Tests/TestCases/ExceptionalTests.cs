


using PlaylistManagementApp.DAL.Interrfaces;
using PlaylistManagementApp.DAL.Services;
using PlaylistManagementApp.DAL.Services.Repository;
using PlaylistManagementApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PlaylistManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IPlaylistService _playlistService;
        public readonly Mock<IPlaylistRepository> playlistservice = new Mock<IPlaylistRepository>();

        private readonly Song _song;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _playlistService = new PlaylistService(playlistservice.Object);

            _output = output;

            _song = new Song
            {
                SongId = 1,
                Album = "Album",
                Artist = "Artist",
                Genre = "Genre",
                Title = "Title"
            };
        }


        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidSongIdIsPassed()
        {
            //Arrange
            bool res = false;
            _song.SongId= 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                playlistservice.Setup(repo => repo.AddSongs(_song)).ReturnsAsync(_song);
                var result = await _playlistService.AddSongs(_song);
                if (result != null || result.SongId !=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidSongArtistIsPassed()
        {
            //Arrange
            bool res = false;
            _song.Artist = "Artist";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                playlistservice.Setup(repo => repo.AddSongs(_song)).ReturnsAsync(_song);
                var result = await _playlistService.AddSongs(_song);
                if (result != null || result.Artist.Length!=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidSongAlbumIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                playlistservice.Setup(repo => repo.AddSongs(_song)).ReturnsAsync(_song);
                var result = await _playlistService.AddSongs(_song);
                if (result != null || result.Album.Length>0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidSongTitleIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                playlistservice.Setup(repo => repo.AddSongs(_song)).ReturnsAsync(_song);
                var result = await _playlistService.AddSongs(_song);
                if (result != null || result.Title !=null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}