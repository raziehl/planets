using System.Net.Http.Headers;

public class ReverseProxyMiddleware
{
  private static readonly HttpClient _httpClient = new HttpClient();
  private readonly RequestDelegate _nextMiddleware;

  private string crewsApiUrl;
  private string planetsApiUrl;

  private readonly ILogger<ReverseProxyMiddleware> _logger;

  public ReverseProxyMiddleware(
    RequestDelegate nextMiddleware,
    ILogger<ReverseProxyMiddleware> logger
  )
  {
    _nextMiddleware = nextMiddleware;
    _logger = logger;


    string? tmpCrewsApi = Environment.GetEnvironmentVariable("CREWS_API");
    string? tmpPlanetsApi = Environment.GetEnvironmentVariable("PLANETS_API");

    if(string.IsNullOrEmpty(tmpCrewsApi))
      throw new Exception("CREW_API environment variable is not set");
    
    if(string.IsNullOrEmpty(tmpPlanetsApi))
      throw new Exception("PLANETS_API environment variable is not set");

    crewsApiUrl = tmpCrewsApi;
    planetsApiUrl = tmpPlanetsApi;

    Console.WriteLine("Reverse Proxy initialized");
  }

  public async Task Invoke(HttpContext context)
  {
    var targetUri = BuildTargetUri(context.Request);

    _logger.LogInformation(
      string.Format(
        "Reverse Proxying {0} to: {1}",
        context.Request.Method,
        targetUri?.ToString()
      )
    );

    if (targetUri != null)
    {
      var targetRequestMessage = CreateTargetMessage(context, targetUri);
      using (var responseMessage = await _httpClient.SendAsync(targetRequestMessage, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted))
      {
        context.Response.StatusCode = (int)responseMessage.StatusCode;
        CopyFromTargetResponseHeaders(context, responseMessage);
        await responseMessage.Content.CopyToAsync(context.Response.Body);
      }
      return;
    }
    await _nextMiddleware(context);
  }

  private HttpRequestMessage CreateTargetMessage(HttpContext context, Uri targetUri)
  {
    var requestMessage = new HttpRequestMessage();
    CopyFromOriginalRequestContentAndHeaders(context, requestMessage);

    requestMessage.RequestUri = targetUri;
    requestMessage.Headers.Host = targetUri.Host;
    requestMessage.Method = GetMethod(context.Request.Method);

    if(!string.IsNullOrEmpty(context.Request.Headers.Authorization)) {
      var jwtToken = ((string)context.Request.Headers.Authorization).Split(' ')[1];
      requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
    }

    return requestMessage;
  }

  private void CopyFromOriginalRequestContentAndHeaders(HttpContext context, HttpRequestMessage requestMessage)
  {
    var requestMethod = context.Request.Method;

    if (!HttpMethods.IsGet(requestMethod) &&
      !HttpMethods.IsHead(requestMethod) &&
      !HttpMethods.IsDelete(requestMethod) &&
      !HttpMethods.IsTrace(requestMethod))
    {
      var streamContent = new StreamContent(context.Request.Body);
      requestMessage.Content = streamContent;
    }

    foreach (var header in context.Request.Headers)
    {
      requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
    }
  }

  private void CopyFromTargetResponseHeaders(HttpContext context, HttpResponseMessage responseMessage)
  {
    foreach (var header in responseMessage.Headers)
    {
      context.Response.Headers[header.Key] = header.Value.ToArray();
    }

    foreach (var header in responseMessage.Content.Headers)
    {
      context.Response.Headers[header.Key] = header.Value.ToArray();
    }
    context.Response.Headers.Remove("transfer-encoding");
  }
  private static HttpMethod GetMethod(string method)
  {
    if (HttpMethods.IsDelete(method)) return HttpMethod.Delete;
    if (HttpMethods.IsGet(method)) return HttpMethod.Get;
    if (HttpMethods.IsHead(method)) return HttpMethod.Head;
    if (HttpMethods.IsOptions(method)) return HttpMethod.Options;
    if (HttpMethods.IsPost(method)) return HttpMethod.Post;
    if (HttpMethods.IsPut(method)) return HttpMethod.Put;
    if (HttpMethods.IsTrace(method)) return HttpMethod.Trace;
    return new HttpMethod(method);
  }

  private Uri? BuildTargetUri(HttpRequest request) {
    Uri? targetUri = null;

    if (request.Path.StartsWithSegments("/crews_gateway", out var remainingPath)) {
      targetUri = new Uri(crewsApiUrl + remainingPath);
    } else if(request.Path.StartsWithSegments("/planets_gateway", out var remainingPath3)) {
      targetUri = new Uri(planetsApiUrl + remainingPath3);
    }

    return targetUri;
  }
}