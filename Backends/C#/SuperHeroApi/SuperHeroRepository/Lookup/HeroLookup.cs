using AutoMapper;
using Dapper;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.DapperModel;
using SuperHeroDomain.Infrastructure.Query;
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

        public HeroLookup(IDbSession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<List<Hero>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<Hero>(LookupSQLQueries.GetAll());

            return result.ToList();
        }

        public async Task<QueryPagedResponse<Hero>> GetAllHeroesPaginated(IPagedRequest context)
        {
            IEnumerable<QueryHero> result;

            (int? firstRow, int? lastRow) = DbPaginationHelper.GetPageIndexes(context.Page, context.PageSize);

            int totalItems;

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
                throw new Exception(ex.Message, ex.InnerException);
            }


            QueryPagedResponse<Hero> response = new QueryPagedResponse<Hero>
            {
                Items = _mapper.Map<List<Hero>>(result),
                CurrentPage = (context.Page ?? 0),
                PageSize = context.PageSize ?? Constants.DEFAULT_PAGE_SIZE,
                TotalItems = totalItems
            };

            return response;
        }

        public async Task<int> GetCountHeroes()
        {
            var result = await _session.Connection.QuerySingleAsync<int>(LookupSQLQueries.GetCountHeroes());

            return result;
        }

        public async Task<Hero> GetHeroByPublicId(string publicHeroId)
        {
            IEnumerable<Hero> result;

            try
            {
                result = await _session.Connection.QueryAsync<Hero>(LookupSQLQueries.GetHeroByPublicId(), new { PUBLIC_ID = publicHeroId });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return result.FirstOrDefault();
        }
    }
}