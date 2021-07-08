using Apsis.Shared.DTO;
using ApsisYönetim.CardService.Configs;
using ApsisYönetim.CardService.DTO;
using ApsisYönetim.CardService.Model;
using ApsisYönetim.CardService.Services.Interfaces;
using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.CardService.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IMongoCollection<CreditCard> _creditCardCollection = null;
        private readonly IMapper _mapper = null;
        public CreditCardService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _creditCardCollection = database.GetCollection<CreditCard>(databaseSettings.CreditCardCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<CreditCardDto>> WithDrawMoney(CreditCardDto cardDto)
        {
            //CreditCard existCard = await _creditCardCollection.Find(
            //    x => x.CardNumber == card.CardNumber &&
            //    x.Cvv == card.Cvv &&
            //    x.ValidMonth == card.ValidMonth &&
            //    x.ValidYear == card.ValidYear)
            //    .FirstOrDefaultAsync();
            
            //if (existCard == null)
            //{
            //    return Response<CreditCard>.Fail("Böyle bir kart bulunumadı", 404);
            //}
            

            //Check if card is exist in database ?
            var result = await GetCreditCard(_mapper.Map<CreditCard>(cardDto));
            

            if (!result.IsSuccess)
            {
                if (result.Errors.Any())
                {
                    return Response<CreditCardDto>.Fail(result.Errors, 404);
                }
            }
            


            CreditCard existCard = result.Data;

            if(!(existCard.Balance >= cardDto.Money))
            {
                return Response<CreditCardDto>.Fail("Bakiye yetersiz", 300);
            }

            existCard.Balance -= cardDto.Money;

            await _creditCardCollection.ReplaceOneAsync(x => x.Id == existCard.Id, existCard);


            return Response<CreditCardDto>.Success(_mapper.Map<CreditCardDto>(existCard), 200);

        }

        public async Task<Response<CreditCard>> GetCreditCard(CreditCard creditCard)
        {
            CreditCard existCard = await _creditCardCollection.Find(
                x => x.CardNumber == creditCard.CardNumber &&
                x.Cvv == creditCard.Cvv &&
                x.ValidMonth == creditCard.ValidMonth &&
                x.ValidYear == creditCard.ValidYear)
                .FirstOrDefaultAsync();


            if(existCard == null)
            {
                return Response<CreditCard>.Fail("Böyle bir kart bulunumadı", 404);
            }

            return Response<CreditCard>.Success(existCard, 200);
        }
    }
}
