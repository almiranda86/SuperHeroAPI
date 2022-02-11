using AutoMapper;
using Dapper;
using SuperHeroCore.Enums;
using SuperHeroCore.Logs.Behavior;
using SuperHeroCore.Logs.Constants;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.DapperModel;
using SuperHeroDomain.Infrastructure.Query;
using SuperHeroDomain.Model;
using SuperHeroDomain.Model.HeroMaster;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Infrastructure.Helpers;
using SuperHeroRepository.Lookup.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroRepository.Lookup
{
    public class HeroLookup : IHeroLookup
    {
        private readonly IDbSession _session;
        private readonly IMapper _mapper;
        private readonly ILogManager _logManager;

        public HeroLookup(IDbSession session, IMapper mapper, ILogManager logManager)
        {
            _session = session;
            _mapper = mapper;
            _logManager = logManager;
        }

        public async Task<List<Hero>> GetAll()
        {
            List<Hero> result = new List<Hero>();

            _logManager.AddTrace(LogTexts.ExecutionFeature(nameof(GetAll), DateTime.Now));

            try
            {
                var queryResult = await _session.Connection.QueryAsync<Hero>(LookupSQLQueries.GetAll());

                result = queryResult.ToList();
            }
            catch (Exception ex)
            {
                _logManager.AddError(Issues.LookupErroGetAll_0001, ex.Message, ex, ex.InnerException);

                throw ex;
            }

            _logManager.AddTrace(LogTexts.EndingExecutionFeature(nameof(GetAllHeroesPaginated), DateTime.Now, result.Count()));

            return result;
        }

        public async Task<QueryPagedResponse<Hero>> GetAllHeroesPaginated(IPagedRequest context)
        {
            IEnumerable<QueryHero> result;

            (int? firstRow, int? lastRow) = DbPaginationHelper.GetPageIndexes(context.Page, context.PageSize);

            int totalItems;

            _logManager.AddTrace(LogTexts.ListaAllHeroesPaginatedExecution(nameof(GetAllHeroesPaginated), DateTime.Now, firstRow.Value, lastRow.Value));

            try
            {
                result = await _session.Connection.QueryAsync<QueryHero>(LookupSQLQueries.GetAllHeroesPaginated(),
                                                                    new
                                                                    {
                                                                        PARAM_FIRST_ROW = firstRow.Value,
                                                                        PARAM_LAST_ROW = lastRow.Value
                                                                    });

                totalItems = result.First().TOTAL_ROWS;
            }
            catch (Exception ex)
            {
                _logManager.AddError(Issues.LookupErrorGetAllHeroesPaginated_0002, ex.Message, ex, ex.InnerException);

                throw ex;
            }


            QueryPagedResponse<Hero> response = new QueryPagedResponse<Hero>
            {
                Items = _mapper.Map<List<Hero>>(result),
                CurrentPage = (context.Page ?? 0),
                PageSize = context.PageSize ?? Constants.DEFAULT_PAGE_SIZE,
                TotalItems = totalItems
            };

            _logManager.AddTrace(LogTexts.EndingExecutionFeature(nameof(GetAllHeroesPaginated), DateTime.Now, response.TotalItems));


            return response;
        }

        public async Task<int> GetCountHeroes()
        {
            int result = 0;

            _logManager.AddTrace(LogTexts.ExecutionFeature(nameof(GetCountHeroes), DateTime.Now));

            try
            {
                result = await _session.Connection.QuerySingleAsync<int>(LookupSQLQueries.GetCountHeroes());
            }
            catch (Exception ex)
            {
                _logManager.AddError(Issues.LookupErrorGetCountHeroes_003, ex.Message, ex, ex.InnerException);

                throw ex;
            }

            _logManager.AddTrace(LogTexts.EndingExecutionFeature(nameof(GetAllHeroesPaginated), DateTime.Now, result));

            return result;
        }

        public async Task<Hero> GetHeroByPublicId(string publicHeroId)
        {
            IEnumerable<Hero> result;

            _logManager.AddTrace(LogTexts.ExecutionFeature(nameof(GetHeroByPublicId), DateTime.Now));

            try
            {
                result = await _session.Connection.QueryAsync<Hero>(LookupSQLQueries.GetHeroByPublicId(), new { PUBLIC_ID = publicHeroId });
            }
            catch (Exception ex)
            {
                _logManager.AddError(Issues.LookupErrorGetHeroByPublicId_004, ex.Message, ex, ex.InnerException);

                throw ex;
            }

            _logManager.AddTrace(LogTexts.EndingExecutionFeature(nameof(GetAllHeroesPaginated), DateTime.Now, result.ToList().Count()));

            return result.FirstOrDefault();
        }

        public async Task<FullHero> GetCompleteHero(string publicHeroId)
        {
            IEnumerable<FullHero> result;

            _logManager.AddTrace(LogTexts.ExecutionFeature(nameof(GetCompleteHero), DateTime.Now));

            try
            {
                result = await _session.Connection.QueryAsync<FullHero>(LookupSQLQueries.GetCompleteHeroByPublicId(), new { PUBLIC_ID = publicHeroId });
            }
            catch (Exception ex)
            {
                _logManager.AddError(Issues.LookupErrorGetCompleteHero_005, ex.Message, ex, ex.InnerException);

                throw ex;
            }

            _logManager.AddTrace(LogTexts.EndingExecutionFeature(nameof(GetCompleteHero), DateTime.Now, result.ToList().Count()));

            return result.FirstOrDefault();
        }
    }
}