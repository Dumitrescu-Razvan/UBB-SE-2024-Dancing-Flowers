using System;
using App.Domain;
using App.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public ObservableCollection<string> getSongs() { 
			List<Song> songs = _songRepository.getAll();
			Console.WriteLine("Is good");
			ObservableCollection<string> songNames = new ObservableCollection<string>();
			foreach (Song song in songs)
			{
				string songString = song.title + " - " + song.artist;
				   songNames.Add(songString);
			}
			return songNames;
			
        }




    }
}
