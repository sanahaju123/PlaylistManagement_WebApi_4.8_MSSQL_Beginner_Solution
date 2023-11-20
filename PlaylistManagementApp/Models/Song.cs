using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaylistManagementApp.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
    }
}