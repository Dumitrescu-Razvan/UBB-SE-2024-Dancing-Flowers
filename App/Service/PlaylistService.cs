using System;
using App.Domain;
using App.Repository;



namespace App.Service
{
  public class PlaylistService
  {

        private readonly PlaylistRepository _playlistRepository;

        /// <summary>
        /// Initializes a new instance of the PlaylistService class.
        /// </summary>
        /// <param name="playlistRepository">The repository for playlist data.</param>
        public PlaylistService(PlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        /// <summary>
        /// Adds a song to a playlist.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist.</param>
        /// <param name="song">The song to be added to the playlist.</param>
        public void AddSongToPlaylist(string id ,Song song)
        {
            try
            {
                var playlist = _playlistRepository.getById(id);
                playlist.addSong(song);
                _playlistRepository.Update(playlist);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add song to the playlist: {ex.Message}");
            }
        }

        /// <summary>
        /// Removes a song from a playlist.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist.</param>
        /// <param name="songId">The unique identifier of the song to be removed.</param>
        public void RemoveSongFromPlaylist(string id, string songId)
        {
            try
            {
                var playlist = _playlistRepository.getById(id);
                playlist.removeSong(songId);
                _playlistRepository.Update(playlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove song from the playlist: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new playlist.
        /// </summary>
        /// <param name="playlist">The playlist to be added.</param>
        public void AddPlaylist(Playlist playlist)
        {
            try
            {
                _playlistRepository.Add(playlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add playlist: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a playlist.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist to be deleted.</param>
        public void DeletePlaylist(string id)
        {
            try
            {
                _playlistRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete playlist: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing playlist.
        /// </summary>
        /// <param name="playlist">The playlist to be updated.</param>
        public void UpdatePlaylist(Playlist playlist)
        {
            try
            {
                _playlistRepository.Update(playlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update playlist: {ex.Message}");
            }
        }

    }
}
