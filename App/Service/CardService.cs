using System;
using App.Domain;
using App.Repository;


namespace App.Service
{
    public class CardService
    {
        private readonly CardRepository _cardRepository;

        public CardPaymentService(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        
        void  CreateCard(string cardNumber, string cvv, string expirationDate)
        {
            try
            {
                var card = new Card(cardNumber, cvv, expirationDate);
                _cardRepository.AddCard(card);
            }
            catch (Exception ex)
            {
                throw new Exception($"Card creation failed: {ex.Message}");
            }
        }
        /// <summary>
        /// Another way to create a card with a balance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="balance"></param>
        /// <param name="cardNumber"></param>
        /// <param name="cvv"></param>
        /// <param name="expirationDate"></param>
        /// <exception cref="Exception"></exception>
        void CreateCardWithBalance(int id, int balance, string cardNumber,string cvv, string expirationDate)
        {
            try
            {
                var card = new Card(id,balance,cardNumber,cvv,expirationDate)
                _cardRepository.AddCard(card);
            }
            catch (Exception ex)
            {
                throw new Exception($"Card creation failed: {ex.Message}");
            }
        }


    }
}
}