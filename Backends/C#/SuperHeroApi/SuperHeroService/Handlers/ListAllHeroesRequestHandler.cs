using MediatR;
using SuperHeroCore.Logs.Behavior;
using SuperHeroCore.Logs.Constants;
using SuperHeroCore.Logs.Model;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.Handlers
{
    public class ListAllHeroesRequestHandler : IRequestHandler<ListAllHeroesRequest, ListAllHeroesResponse>
    {
        private readonly IHeroLookup _heroLookup;
        private readonly ILogManager _logManager;
        ProcessLog _processLog;
        public ListAllHeroesRequestHandler(IHeroLookup heroLookup,
                                           ILogManager logManager)
        {
            _heroLookup = heroLookup;
            _logManager = logManager;
        }

        public async Task<ListAllHeroesResponse> Handle(ListAllHeroesRequest request, CancellationToken cancellationToken)
        {
            _logManager.AddTrace(LogTexts.BegginingExecution(nameof(ListAllHeroesRequestHandler.Handle), DateTime.Now));

            ListAllHeroesResponse listAllHeroesResponse = new ListAllHeroesResponse();

            try
            {
                _processLog = new ProcessLog()
                {
                    FunctionName = typeof(ListAllHeroesRequestHandler).FullName,
                    MethodName = nameof(Handle),
                    Payload = request
                };

                var response = await _heroLookup.GetAll();

                _processLog.Success = true;
                _processLog.Response = response;
                _processLog.ProcessingStatus = ProccessStatus.ProccessOk;

                listAllHeroesResponse.StatusDescription = ProccessStatus.ProccessOk;
                listAllHeroesResponse.Heroes = response;
                listAllHeroesResponse.SetOk();
            }
            catch(Exception ex)
            {
                listAllHeroesResponse.StatusDescription = ProccessStatus.ProccessNotOk;
                listAllHeroesResponse.SetInternalServerError();
                _processLog.Success = false;
                _processLog.Exception = ex;
                _processLog.ProcessingStatus = ProccessStatus.ProccessNotOk;
            }
            finally
            {
                _logManager.AddProcessLog(_processLog);
            }

            _logManager.AddTrace(LogTexts.EndingExecution(nameof(ListAllHeroesRequestHandler.Handle), DateTime.Now));

            return listAllHeroesResponse;
        }
    }
}
