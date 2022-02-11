using MediatR;
using SuperHeroCore.Logs.Behavior;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.Infrastructure.Extensions;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using SuperHeroCore.Logs.Constants;
using SuperHeroCore.Logs.Model;

namespace SuperHeroService.Handlers
{
    public class ListAllHeroesPaginatedRequestHandler : IRequestHandler<ListAllHeroesPaginatedRequest, ListAllHeroesPaginatedResponse>
    {
        private readonly IHeroLookup _heroLookup;
        private readonly ILogManager _logManager;
        ProcessLog _processLog;

        public ListAllHeroesPaginatedRequestHandler(IHeroLookup heroLookup, ILogManager logManager)
        {
            _heroLookup = heroLookup;
            _logManager = logManager;
        }

        public async Task<ListAllHeroesPaginatedResponse> Handle(ListAllHeroesPaginatedRequest request, CancellationToken cancellationToken)
        {
            _logManager.AddTrace(LogTexts.BegginingExecution(nameof(ListAllHeroesPaginatedRequestHandler), DateTime.Now));

            var response = new ListAllHeroesPaginatedResponse();

            try
            {
                _processLog = new ProcessLog()
                {
                    FunctionName = typeof(ListAllHeroesPaginatedRequestHandler).FullName,
                    MethodName = nameof(Handle),
                    Payload = request
                };

                var pagedResponse = await _heroLookup.GetAllHeroesPaginated(request);

                response = pagedResponse.FromIPagedResponse<ListAllHeroesPaginatedResponse>();
                response.Heroes = pagedResponse.Items;
                response.StatusDescription = ProccessStatus.ProccessOk;
                response.SetOk();

                _processLog.Success = true;
                _processLog.Response = pagedResponse;
                _processLog.ProcessingStatus = ProccessStatus.ProccessOk;

            }
            catch (Exception ex)
            {
                response.StatusDescription = ProccessStatus.ProccessNotOk;
                response.SetInternalServerError();
                _processLog.Success = false;
                _processLog.Exception = ex;
                _processLog.ProcessingStatus = ProccessStatus.ProccessNotOk;
            }
            finally
            {
                _logManager.AddProcessLog(_processLog);
            }

            _logManager.AddTrace(LogTexts.EndingExecution(nameof(ListAllHeroesPaginatedRequestHandler), DateTime.Now));

            return response;
        }
    }
}
