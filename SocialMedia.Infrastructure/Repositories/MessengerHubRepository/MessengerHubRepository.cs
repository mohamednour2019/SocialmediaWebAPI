﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Infrastructure.DatabaseContext;
using SocialMedia.SharedKernel.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories.MessengerHubRepository
{
    public class MessengerHubRepository : IMessengerHubRepository
    {
        private AppDbContext _appDbContext;
        private DbSet<MessengerHub> _messengerHubs;
        public MessengerHubRepository(AppDbContext appDbContext) { 
            _appDbContext = appDbContext;
            _messengerHubs= appDbContext.Set<MessengerHub>();   
        }
        public async Task AddConnectionAsync(MessengerHub userConnection)
        {
            await _messengerHubs.AddAsync(userConnection);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteConnectionAsync(Guid userId)
        {
            var userConnection=await _messengerHubs.FirstOrDefaultAsync(x => x.UserId == userId);
            if(userConnection!=null) {
                _messengerHubs.Remove(userConnection);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<MessengerHub> GetConnectionAsync(Guid userId)
        {
           MessengerHub userConnectoin= await _messengerHubs.FindAsync(userId);
            return userConnectoin;
        }

        public async Task DeleteUserConnection(Guid userId)
        {
            MessengerHub messengerHub= await _appDbContext.MessengerHub.FindAsync(userId);
            try
            {
                _appDbContext.MessengerHub.Remove(messengerHub);
                await _appDbContext.SaveChangesAsync();
  
            }catch(Exception ex)
            {
                throw new ViolenceValidationException("user not connented!");
            }
        }
    }
}
