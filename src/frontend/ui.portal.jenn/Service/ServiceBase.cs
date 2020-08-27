 
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
 
 
using ui.portal.jenn.Handler;


namespace ui.portal.jenn.Service
{
    public class ServiceBase : IDisposable
    {

        private HttpClient httpClient;
        private ILogger<ServiceBase> logger;

        public ServiceBase(HttpClient _httpClient, ILogger<ServiceBase> _logger)
        {
            this.httpClient = _httpClient;
            this.logger = _logger;

            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            finally
            {

            }
        }


        public async Task<CommandResult> PostAsync(CommandInput model)
        {
            var parametro = new StringContent(JsonConvert.SerializeObject(model.Data, Formatting.Indented), Encoding.UTF8, "application/json");
            CommandResult retorno;

            using (var httpResponse = await this.httpClient.PostAsync($"api/{model.UrlAction}", parametro))
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseStream = await httpResponse.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<CommandResult>(responseStream);
                }
                else
                    retorno = new CommandResult(false, httpResponse.RequestMessage.ToString(), "", null,
                        httpResponse.StatusCode);
            }
            return retorno;
        }

        public async Task<CommandResult> DetailAsync(CommandInput model)
        {
            CommandResult retorno;
            try
            {


                var httpResponse = await this.httpClient.GetAsync($"api/{model.UrlAction}");
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var responseStream = await httpResponse.Content.ReadAsStringAsync();
                        retorno = JsonConvert.DeserializeObject<CommandResult>(responseStream);
                    }
                    else
                        retorno = new CommandResult(false, httpResponse.RequestMessage.ToString(), "", null, HttpStatusCode.BadRequest);
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu o Seguinte Erro [{exception.Message}]", exception);
                throw;
            }
            return retorno;
        }



        public async Task<CommandResult> GetAsync(CommandInput model)
        {
            CommandResult retorno;
            try
            {
                var httpResponse = await this.httpClient.GetAsync($"api/{model.UrlAction}");
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var responseStream = await httpResponse.Content.ReadAsStringAsync();
                        retorno = JsonConvert.DeserializeObject<CommandResult>(responseStream);
                    }
                    else
                        retorno = new CommandResult(false, httpResponse.RequestMessage.ToString(), "", null, HttpStatusCode.BadRequest);
                }
            }

            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu o Seguinte Erro [{exception.Message}] Inner Exception [{exception.InnerException}]", exception);
                throw;
            }
            return retorno;
        }

    }
}


//public async Task<ICommandResult> DeleteAsync(ICommandInput model)
//{
//        //CommandResult.CommandResult retorno;
//        //try
//        //{

//        //    using (var request = new HttpRequestMessage())
//        //    {
//        //        var client = this.clientFactory.CreateClient();
//        //        {
//        //            using (var httpResponse = await client.DeleteAsync($"/{model.UrlAction}"))
//        //            {
//        //                if (httpResponse.IsSuccessStatusCode)
//        //                {
//        //                    using (var responseStream = await httpResponse.Content.ReadAsStreamAsync())
//        //                        retorno = await JsonSerializer.DeserializeAsync<CommandResult.CommandResult>(responseStream);
//        //                }
//        //                else
//        //                    retorno = new CommandResult.CommandResult(false, httpResponse.RequestMessage.ToString(), null,
//        //                        httpResponse.StatusCode);
//        //            }
//        //        }
//        //    }
//        //    return retorno;
//        //}
//        //catch (Exception ex)
//        //{
//        //    this.logger.LogError($"Ocorreu o seguinte errro [{ex.Message}]", ex);

//        //    throw;
//        //}
//        throw new NotImplementedException();
//    }

//public async Task<ICommandResult> DetailAsync(ICommandInput model)
//{
//        //CommandResult.CommandResult retorno;
//        //using (var request = new HttpRequestMessage())
//        //{
//        //    var client = this.clientFactory.CreateClient();
//        //    {
//        //        using (var httpResponse = await client.GetAsync($"/{model.UrlAction}"))
//        //        {
//        //            if (httpResponse.IsSuccessStatusCode)
//        //            {
//        //                using (var responseStream = await httpResponse.Content.ReadAsStreamAsync())
//        //                    retorno = await JsonSerializer.DeserializeAsync<CommandResult.CommandResult>(responseStream);
//        //            }
//        //            else
//        //                retorno = new CommandResult.CommandResult(false, httpResponse.RequestMessage.ToString(), null,
//        //                    httpResponse.StatusCode);
//        //        }
//        //    }
//        //}
//        //return retorno;
//        throw new NotImplementedException();
//    }



//public async Task<ICommandResult> PostAsync(ICommandInput model)
//{
//    //var parametro = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
//    //    CommandResult.CommandResult retorno = new CommandResult.CommandResult();
//    //    //using (var request = new HttpRequestMessage())
//        //{
//        //    var client = this.clientFactory.CreateClient();
//        //    {
//        //        using (var httpResponse = await client.PostAsync($"/{model.UrlAction}", parametro))
//        //        {
//        //            if (httpResponse.IsSuccessStatusCode)
//        //            {
//        //                using (var responseStream = await httpResponse.Content.ReadAsStreamAsync())
//        //                    retorno = await JsonSerializer.DeserializeAsync<CommandResult.CommandResult>(responseStream);
//        //            }
//        //            else
//        //                retorno = new CommandResult.CommandResult(false, httpResponse.RequestMessage.ToString(), null,
//        //                    httpResponse.StatusCode);
//        //        }


//        //    }
//        //}
//        throw new NotImplementedException();
//}

//public async Task<ICommandResult> PutAsync(ICommandInput model)
//{
//        //var parametro = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
//        //CommandResult.CommandResult retorno;
//        //using (var request = new HttpRequestMessage())
//        //{
//        //    var client = this.clientFactory.CreateClient();
//        //    {
//        //        using (var httpResponse = await client.PutAsync($"/{model.UrlAction}", parametro))
//        //        {
//        //            if (httpResponse.IsSuccessStatusCode)
//        //            {
//        //                using (var responseStream = await httpResponse.Content.ReadAsStreamAsync())
//        //                    retorno = await JsonSerializer.DeserializeAsync<CommandResult.CommandResult>(responseStream);
//        //            }
//        //            else
//        //                retorno = new CommandResult.CommandResult(false, httpResponse.RequestMessage.ToString(), null,
//        //                    httpResponse.StatusCode);
//        //        }
//        //    }
//        //}
//        //return retorno;
//        throw new NotImplementedException();
//    }
