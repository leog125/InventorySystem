﻿using Context.Data;
using Repository.GenericRepository.Interfaces;
using Repository.SpecificRepository.Implentations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.GenericRepository.Implentations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IWineryRepository WineryRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            WineryRepository = new WineryRepository(this.context);

        }
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
