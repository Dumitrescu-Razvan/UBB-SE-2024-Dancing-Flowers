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

        /// <summary>
        /// Makes a payment using the specified card.
        /// </summary>
        /// <param name="cardNumber">The unique identifier of the card.</param>
        /// <param name="amount">The amount to be paid.</param>
        /// <exception cref="Exception">Thrown when card not found or payment fails.</exception>
        public void MakePayment(string cardNumber, float amount)
        {
            try
            {
                // Get the card from the database by card number
                var card = _cardRepository.getById(cardNumber);

                if (card == null)
                {
                    throw new Exception("Card not found.");
                }

                // Make payment
                card.Pay(amount);

                // Update the card balance in the database
                _cardRepository.Update(card);
            }
            catch (Exception ex)
            {
                throw new Exception($"Payment failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds funds to the specified card.
        /// </summary>
        /// <param name="cardNumber">The unique identifier of the card.</param>
        /// <param name="amount">The amount of funds to be added.</param>
        /// <exception cref="Exception">Thrown when card not found.</exception>
        public void AddFunds(string cardNumber, float amount)
        {
            // Get the card from the database by card number
            var card = _cardRepository.getById(cardNumber);

            if (card == null)
            {
               throw new Exception("Card not found.");
            }

            // Add funds
            card.AddFunds(amount);

            // Update the card balance in the database
            _cardRepository.Update(card);
            
        }

        /// <summary>
        /// Retrieves the balance of the specified card.
        /// </summary>
        /// <param name="cardNumber">The unique identifier of the card.</param>
        /// <returns>The balance of the card.</returns>
        /// <exception cref="Exception">Thrown when card not found.</exception>
        public float GetBalance(string cardNumber)
        {
            var card = _cardRepository.getById(cardNumber);
            if (card == null)
            {
                throw new Exception("Card not found.");
            }

            var balance = card.GetBalance();
            return balance;
        }

        /// <summary>
        /// Creates a new card with the specified details.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="cvv">The CVV of the card.</param>
        /// <param name="expirationDate">The expiration date of the card.</param>
        /// <param name="balance">The initial balance of the card (optional, default is 0).</param>
        /// <exception cref="Exception">Thrown when card creation fails.</exception>
        public void CreateCard(string cardNumber, string cvv, string expirationDate, float balance = 0)
        {
            try
            {
                // Create a new card
                var card = new Card(cardNumber, cvv, expirationDate, balance);

                // Add the card to the database
                _cardRepository.AddCard(card);
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Card creation failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the details of the specified card.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="cvv">The new CVV of the card.</param>
        /// <param name="expirationDate">The new expiration date of the card.</param>
        /// <param name="balance">The new balance of the card.</param>
        /// <exception cref="Exception">Thrown when card not found or update fails.</exception>
        public void UpdateCard(string cardNumber, string cvv, string expirationDate, float balance)
        {
            try
            {
                // Get the card from the database by card number
                var card = _cardRepository.getById(cardNumber);

                if (card == null)
                {
                    Console.WriteLine("Card not found.");
                    return;
                }

                // Update the card details
                card.Cvv = cvv;
                card.ExpirationDate = expirationDate;
                card.Balance = balance;

                // Update the card in the database
                _cardRepository.Update(card);
                Console.WriteLine("Card updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Card update failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes the specified card.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <exception cref="Exception">Thrown when card not found or deletion fails.</exception>
        public void DeleteCard(string cardNumber)
        {
            try
            {
                // Get the card from the database by card number
                var card = _cardRepository.getById(cardNumber);

                if (card == null)
                {
                    throw new Exception("Card not found.");
                }

                // Delete the card from the database
                _cardRepository.Delete(card);
            }
            catch (Exception ex)
            {
                throw new Exception($"Card deletion failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all cards from the repository.
        /// </summary>
        /// <returns>A list of all cards.</returns>
        public List<Card> GetAllCards()
        {
            // Retrieve all cards from the repository
            var cards = _cardRepository.GetAllCards();

            // Return the cards as the specified type
            return cards;
        }


        /// <summary>
        /// Retrieves a card from the repository by its number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns>The card with the specified number.</returns>
        /// <exception cref="Exception">Thrown when card not found.</exception>
        public Card GetCardByNumber(string cardNumber)
        {
            // Get the card from the database by card number
            var card = _cardRepository.GetCardByNumber(cardNumber);

            if (card == null)
            {
               throw new Exception("Card not found.");
            }

            return card;
        }

    }
}
}