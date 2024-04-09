using System;
using App.Domain;
using App.Repository;
using System.Collections.Generic;

namespace App.Service
{
	public class AdService
	{
        private readonly AdRepository _adRepository;

        //new instance of AdService class
        public AdService(AdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        //add a new ad to system
        public void AddAd(Ad ad)
        {
            try { _adRepository.Add(ad); }
            catch (ArgumentException ex) { Console.WriteLine("Ad add error"); }
        }

        //retrieve all ads
        public Ad GetById(int id)
        {
            return _adRepository.Find(_adRepository => _adRepository.Id == id);
        }

        //update ad information
        public void UpdateAd(Ad updatedAd)
        {
            Ad adToUpdate = _adRepository.Find(ads => ads.Id == updatedAd.Id);
            if(adToUpdate != null)
            {
                adToUpdate.Duration = updatedAd.Duration;
                adToUpdate.TimesPlayed = updatedAd.TimesPlayed;
                adToUpdate.Clicks = updatedAd.Clicks;
            }
            else
            {
                throw new ArgumentException("Ad not found");
            }
        }

        //remove ad from system
        public void RemoveAd(int id)
        {
            Ad adToRemove = _adRepository.Find(ads => ads.Id == id);
            if(adToRemove != null)
            {
                _adRepository.Remove(adToRemove);
            }
            else
            {
                throw new ArgumentException("Ad not found");
            }
        }

        //track when ad is clicked
        public void TrackAdClick(int id)
        {
            Ad ad = _adRepository.Find(ads => _adRepository.Id == id);
            if(ad != null) { ad.clicked(); }
            else { throw new ArgumentException("Ad not found"); }
        }
    }
}
