using MediatR;
using Microsoft.Extensions.Configuration;
using SuperHeroCore.Extension;
using SuperHeroCore.Logs.Behavior;
using SuperHeroCore.Logs.Constants;
using SuperHeroCore.Logs.Model;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.CustomModel;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.Handlers
{
    public class GetCompleteHeroByPublicIdRequestHandler : IRequestHandler<GetCompleteHeroByIdRequest, GetCompleteHeroByIdResult>
    {
        private readonly IHeroLookup _heroLookup;
        private readonly ILogManager _logManager;
        ProcessLog _processLog;
        public GetCompleteHeroByPublicIdRequestHandler(IHeroLookup heroLookup,
                                                       ILogManager logManager)
        {
            _heroLookup = heroLookup;
            _logManager = logManager;
        }

        public async Task<GetCompleteHeroByIdResult> Handle(GetCompleteHeroByIdRequest request, CancellationToken cancellationToken)
        {
            _logManager.AddTrace(LogTexts.BegginingExecution(nameof(GetCompleteHeroByPublicIdRequestHandler.Handle), DateTime.Now));

            GetCompleteHeroByIdResult result = new GetCompleteHeroByIdResult();

            try
            {
                _processLog = new ProcessLog()
                {
                    FunctionName = typeof(GetCompleteHeroByPublicIdRequestHandler).FullName,
                    MethodName = nameof(Handle),
                    Payload = request
                };

                var responseHero = await _heroLookup.GetCompleteHero(request.PublicHeroId);

                result.completeHero = responseHero.HERO.FromJson<CompleteHero>();
                result.StatusDescription = ProccessStatus.ProccessOk;
                result.SetOk();

                _processLog.Success = true;
                _processLog.Response = result;
                _processLog.ProcessingStatus = ProccessStatus.ProccessOk;
            }
            catch (Exception ex)
            {
                result.StatusDescription = ProccessStatus.ProccessNotOk;
                result.SetInternalServerError();
                _processLog.Success = false;
                _processLog.Exception = ex;
                _processLog.ProcessingStatus = ProccessStatus.ProccessNotOk;


                _logManager.AddError(SuperHeroCore.Enums.Issues.GetCompleteHeroByPublicIdRequestHandler_0001,
                                    LogTexts.ErrorWhenGettingCompleteHero(nameof(GetCompleteHeroByPublicIdRequestHandler.Handle), DateTime.Now, request.PublicHeroId, ex.Message));
            }
            finally
            {
                _logManager.AddProcessLog(_processLog);
            }

            _logManager.AddTrace(LogTexts.EndingExecution(nameof(GetCompleteHeroByPublicIdRequestHandler.Handle), DateTime.Now));

            return result;
        }
    }
}
