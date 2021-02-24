
using Bit.Http.Implementations;
using System.Collections.Generic;
using Bit.Core.Implementations;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Bit.Http.Contracts;

namespace System.Net.Http
{
						namespace Auto { [System.CodeDom.Compiler.GeneratedCode("BitCodeGenerator", "7.0.0.0")] public class AutoMathDto : Bit.Model.Contracts.IDto { public System.Guid Id { get; set; } } }
								namespace Auto { [System.CodeDom.Compiler.GeneratedCode("BitCodeGenerator", "7.0.0.0")] public class AutoWeatherDto : Bit.Model.Contracts.IDto { public System.Guid Id { get; set; } } }
			
	[System.CodeDom.Compiler.GeneratedCode("BitCodeGenerator", "7.0.0.0")]
    public static class ATACheckContextExt
    {
		
			public static ODataHttpClient<Auto.AutoMathDto> Math(this HttpClient httpClient)
			{
				return new ODataHttpClient<Auto.AutoMathDto>(httpClient, "Math" , "ATACheck" );
			}

			
				public static async Task<int> Sum(this ODataHttpClient<Auto.AutoMathDto> mathController,int n1,int n2,ODataContext? oDataContext = default,CancellationToken cancellationToken = default)
				{
					string qs = oDataContext?.Query is not null ? $"?{oDataContext.Query}" : string.Empty;
					string requestUri = $"odata/ATACheck/Math/Sum(n1={(n1 == null ? "null" : $"{n1}")},n2={(n2 == null ? "null" : $"{n2}")}){qs}";
					using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
										using HttpResponseMessage response = (await mathController.HttpClient.SendAsync(request, cancellationToken)).EnsureSuccessStatusCode();
											using Stream responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
						var oDataResponse = await DefaultJsonContentFormatter.Current.DeserializeAsync<ODataResponse<int>>(responseStream, cancellationToken);
						if (oDataContext is not null)
							oDataContext.TotalCount = oDataResponse.TotalCount;
						return oDataResponse.Value;
									}

			
		
			public static ODataHttpClient<Auto.AutoWeatherDto> Weather(this HttpClient httpClient)
			{
				return new ODataHttpClient<Auto.AutoWeatherDto>(httpClient, "Weather" , "ATACheck" );
			}

			
				public static async Task<List<ATA.Check.Shared.WeatherForecast>> GetWeatherForecasts(this ODataHttpClient<Auto.AutoWeatherDto> weatherController,ODataContext? oDataContext = default,CancellationToken cancellationToken = default)
				{
					string qs = oDataContext?.Query is not null ? $"?{oDataContext.Query}" : string.Empty;
					string requestUri = $"odata/ATACheck/Weather/GetWeatherForecasts(){qs}";
					using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
										using HttpResponseMessage response = (await weatherController.HttpClient.SendAsync(request, cancellationToken)).EnsureSuccessStatusCode();
											using Stream responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
						var oDataResponse = await DefaultJsonContentFormatter.Current.DeserializeAsync<ODataResponse<List<ATA.Check.Shared.WeatherForecast>>>(responseStream, cancellationToken);
						if (oDataContext is not null)
							oDataContext.TotalCount = oDataResponse.TotalCount;
						return oDataResponse.Value;
									}

			
		    }
}
