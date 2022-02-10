using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using SuperHeroCore.Extension;
using SuperHeroCore.Logs.Behavior;
using SuperHeroCore.Logs.Constants;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.CustomModel;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Persister.SQL;

namespace SuperHeroRepository.Persister
{
    public class HeroPersister : IHeroPersister
    {
        private readonly IDbSession _session;
        private readonly IMapper _mapper;
        private readonly ILogManager _logManager;


        public HeroPersister(IDbSession session, IMapper mapper, ILogManager logManager)
        {
            _session = session;
            _mapper = mapper;
            _logManager = logManager;
        }

        public async Task<int> CreateHero(Guid publicId, CompleteHero completeHero, CancellationToken cancellationToken)
        {

            try
            {
                var result = await _session.Connection.QueryAsync<int>(PersisterSQLQueries.CreateCompleteHero(),
                                                                  new
                                                                  {
                                                                      PUBLIC_ID = publicId,
                                                                      COMPLETE_HERO = completeHero.ToJson()
                                                                  });
            }
            catch (Exception ex)
            {
                _logManager.AddError(SuperHeroCore.Enums.Issues.HeroPersisterError_0001, LogTexts.ErrorWhenCreatingHero(nameof(HeroPersister.CreateHero), DateTime.Now, ex.Message));
                return -1;
            }

            return 0;
        }
    }
}
