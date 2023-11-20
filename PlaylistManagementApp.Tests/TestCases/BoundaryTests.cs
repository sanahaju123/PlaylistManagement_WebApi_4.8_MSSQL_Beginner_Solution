

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
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IPlaylistService _playlistService;
        public readonly Mock<IPlaylistRepository> playlistservice = new Mock<IPlaylistRepository>();

        private readonly Song _song;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_SongTitle_NotEmpty()
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
                var actualLength = _song.Title.ToString().Length;
                if (result.Title.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Song_Artist_NotEmpty()
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
                var actualLength = _song.Artist.ToString().Length;
                if (result.Artist.ToString().Length == actualLength)
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