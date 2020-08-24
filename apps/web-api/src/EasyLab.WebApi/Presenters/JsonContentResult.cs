using Microsoft.AspNetCore.Mvc;



namespace EasyLab.WebApi.Presenters

{

  public sealed class JsonContentResult : ContentResult

  {

    public JsonContentResult()

    {

      ContentType = "application/json";

    }

  }

}
