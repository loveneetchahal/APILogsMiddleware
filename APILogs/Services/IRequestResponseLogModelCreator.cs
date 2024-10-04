using APILogs.DbContexts;
using APILogs.Dtos;
using APILogs.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace APILogs.Services
{
    public interface IRequestResponseLogModelCreator
    {
        RequestResponseLogModel LogModel { get; }
        string LogString();
    }

    public class RequestResponseLogModelCreator : IRequestResponseLogModelCreator
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestResponseLogModel LogModel { get; private set; }

        public RequestResponseLogModelCreator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            LogModel = new RequestResponseLogModel();
        }

        public string LogString()
        {          
            using (var scope = _serviceProvider.CreateScope())
            {
                var _mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                var _appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                RequestLogs _requestLogs = new RequestLogs();

                // Map with options
                _mapper.Map(LogModel, _requestLogs, opts =>
                {
                    opts.AfterMap((src, dest) =>
                    {
                        dest.RequestQueries = string.Join(", ", src.RequestQueries.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                        dest.RequestHeaders = string.Join(", ", src.RequestHeaders.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                        dest.ResponseHeaders = string.Join(", ", src.ResponseHeaders.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                    });
                });

                _appDbContext.RequestLogs.Add(_requestLogs);

                try
                {
                    _appDbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }

            var jsonString = JsonConvert.SerializeObject(LogModel);
            return jsonString;
        }
    }
}
