using System;
using App.Domain;
using App.Repository;
using System.Collections.Generic;

namespace App.Service
{
	public class SongService
	{
		private readonly SongRepository _songRepository;
		
		//new instance of SongService class
		public SongService(SongRepository songRepository)
		{
			_songRepository = songRepository;
		}

		//add song to system
		public void AddSong(Song song)
		{
			try { _songRepository.Add(song); }
            catch (ArgumentException ex) { Comsole.WriteLine($"Song add error."); }
        }

		//retrieve a specific song by its Id
		public Song GetSongById(int id)
		{
			return _songRepository.Find(song => song.Id == id);
		}

        //update song information
        public void UpdateSong(Song updatedSong)
        {
            try
            {
                Song songToUpdate = _songRepository.Find(song => song.Id == updatedSong.Id);
                if (songToUpdate != null)
                {
                    songToUpdate.Artist = updatedSong.Artist;
                    songToUpdate.Album = updatedSong.Album;
                    songToUpdate.Duration = updatedSong.Duration;
                    songToUpdate.Likes = updatedSong.Likes;
                    songToUpdate.Shares = updatedSong.Shares;
                    songToUpdate.Saves = updatedSong.Saves;
                    songToUpdate.Restrictions = updatedSong.Restrictions;
                }
                else
                {
                    throw new ArgumentException("Song not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //remove a song from system
        public void RemoveSong(int id)
        {
            try
            {
                Song songToRemove = _songRepository.Find(song => song.Id == id);
                if (songToRemove != null)
                {
                    _songRepository.Remove(songToRemove);
                }
                else
                {
                    throw new ArgumentException("Song not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //handle liking a song
        public void LikeSong(int id)
        {
            try
            {
                Song song = _songRepository.Find(song => song.Id == id);
                if (song != null)
                {
                    song.Like();
                }
                else
                {
                    throw new ArgumentException("Song not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //handle sharing a song
        public void ShareSong(int id)
        {
            try
            {
                Song song = _songRepository.Find(song => song.Id == id);
                if (song != null)
                {
                    song.Share();
                }
                else
                {
                    throw new ArgumentException("Song not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //handle saving a song
        public void SaveSong(int id)
        {
            try
            {
                Song song = _songRepository.Find(song => song.Id == id);
                if (song != null)
                {
                    song.Save();
                }
                else
                {
                    throw new ArgumentException("Song not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
