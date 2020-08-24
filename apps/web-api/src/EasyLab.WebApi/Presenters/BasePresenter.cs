using System.Net;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.WebApi.Serialization;

namespace EasyLab.WebApi.Presenters
{
    public sealed class BasePresenter : IOutputPort<UseCaseResponseMessage>
    {
        public JsonContentResult ContentResult { get; }

        public BasePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(UseCaseResponseMessage response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
